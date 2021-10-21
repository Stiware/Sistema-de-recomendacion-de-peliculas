using System;
using System.IO;

using Microsoft.ML;

using Sistema_de_Recomendacion.Models;


namespace Sistema_de_Recomendacion
{
    class Predictions
    {
        private  string strMovRecomended;
        public string MovRecomended { get => strMovRecomended; }
        private  bool blnLikeOrNot;
        public bool LikeOrNot{ get => blnLikeOrNot; }

        private static string BaseModelRelativePath = @"../../../Model";
        private static string ModelRelativePath = $"{BaseModelRelativePath}";

        private static string BaseDataSetRelativepath = @"../../../Data";
        private static string TrainingDataRelativePath = $"{BaseDataSetRelativepath}/ratings_train.csv";
        private static string TestDataRelativePath = $"{BaseDataSetRelativepath}/ratings_test.csv";

        private static string TrainingDataLocation = GetAbsolutePath(TrainingDataRelativePath);
        private static string TestDataLocation = GetAbsolutePath(TestDataRelativePath);
        private static string ModelPath = GetAbsolutePath(ModelRelativePath);


        public void Process(string idUser, string idMovie)
        {
            //Call the following piece of code for splitting the ratings.csv into ratings_train.csv and ratings.test.csv.
            // Program.DataPrep();

            //STEP 1: Create MLContext to be shared across the model creation workflow objects
            MLContext mlContext = new MLContext();

            //STEP 2: Read data from text file using TextLoader by defining the schema for reading the movie recommendation datasets and return dataview.
            var trainingDataView = mlContext.Data.LoadFromTextFile<MovieRating>(path: TrainingDataLocation, hasHeader: true, separatorChar: ',');

            // ML.NET doesn't cache data set by default. Therefore, if one reads a data set from a file and accesses it many times, it can be slow due to
            // expensive featurization and disk operations. When the considered data can fit into memory, a solution is to cache the data in memory. Caching is especially
            // helpful when working with iterative algorithms which needs many data passes. Since SDCA is the case, we cache. Inserting a
            // cache step in a pipeline is also possible, please see the construction of pipeline below.
            trainingDataView = mlContext.Data.Cache(trainingDataView);

            //STEP 4: Transform your data by encoding the two features userId and movieID.
            //        These encoded features will be provided as input to FieldAwareFactorizationMachine learner
            var dataProcessPipeline = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "userIdFeaturized", inputColumnName: nameof(MovieRating.movieId))
                                          .Append(mlContext.Transforms.Text.FeaturizeText(outputColumnName: "movieIdFeaturized", inputColumnName: nameof(MovieRating.movieId))
                                          .Append(mlContext.Transforms.Concatenate("Features", "userIdFeaturized", "movieIdFeaturized")));

            // STEP 5: Train the model fitting to the DataSet
            var trainingPipeLine = dataProcessPipeline.Append(mlContext.BinaryClassification.Trainers.FieldAwareFactorizationMachine(new string[] { "Features" }));
            var model = trainingPipeLine.Fit(trainingDataView);

            //STEP 6: Evaluate the model performance
            var testDataView = mlContext.Data.LoadFromTextFile<MovieRating>(path: TestDataLocation, hasHeader: true, separatorChar: ',');

            var prediction = model.Transform(testDataView);

            var metrics = mlContext.BinaryClassification.Evaluate(data: prediction, labelColumnName: "Label", scoreColumnName: "Score", predictedLabelColumnName: "PredictedLabel");
            //STEP 7:  Try/test a single prediction by predicting a single movie rating for a specific user
            var predictionEngine = mlContext.Model.CreatePredictionEngine<MovieRating, MovieRatingPrediction>(model);
            MovieRating testData = new MovieRating() { userId = idUser, movieId = idMovie };

            var movieRatingPrediction = predictionEngine.Predict(testData);
            strMovRecomended = $"El usuario con id:{testData.userId} tiene un probabilidad de:{Sigmoid(movieRatingPrediction.Score)}% de gustarele esta pelicula";
            blnLikeOrNot = Convert.ToBoolean(testData.Label);

            //STEP 8:  Save model to 
            Console.WriteLine(); mlContext.Model.Save(model, trainingDataView.Schema, ModelPath);

            ITransformer trainedModel;
            using (FileStream stream = new FileStream(ModelPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                trainedModel = mlContext.Model.Load(stream, out var modelInputSchema);
            }

        }

        private float Sigmoid(float x)
        {
            return (float)(100 / (1 + Math.Exp(-x)));
        }

        private static string GetAbsolutePath(string relativeDatasetPath)
        {
            FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;

            string fullPath = Path.Combine(assemblyFolderPath, relativeDatasetPath);

            return fullPath;
        }


    }
}
