using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
 * This contains the K-Means implementation that will cluster all given problems together
 * */
namespace OwLProject {
    class KMeans {

        private List<List<int>> listOfData;
        private List<int> PID;
        private Dictionary<int, int> whatPoint;

        /**
         * The constructor of KMeans
         * @param   listOfData      Holds each PID's difficulty and type
         * @param   PID             Holds every PID, the 0th index of PID and listOfData
         *                             should be from the same PID
         * */
        public KMeans(List<List<int>> listOfData, List<int> PID) {
            this.listOfData = listOfData;
            this.PID = PID;
            this.whatPoint = new Dictionary<int, int>();
            for (int row = 0; row < (listOfData.Count); ++row) {
                whatPoint[row] = row;
            }
        }

        /**
         * Finds the min and max value of the given column
         * */
        private List<float> findMinMaxVals(int attributeIndex) {
            float minVal = float.MaxValue;
            float maxVal = float.MinValue;
            foreach (List<int> row in listOfData) {
                if (row[attributeIndex] < minVal) {
                    minVal = row[attributeIndex];
                }
                if (row[attributeIndex] > maxVal) {
                    maxVal = row[attributeIndex];
                }
            }
            List<float> returnList = new List<float> { minVal, maxVal };
            return (returnList);
        }

        /**
         * Creates the centers List<list> that keeps track of each center 
         * of the cluster
         * */
        private List<List<float>> createListOfCenters(int k) {
            List<List<float>> centers = new List<List<float>>();
            for (int numberOfK = 0; numberOfK < k; ++numberOfK) {
                centers.Add(new List<float>());
            }
            List<List<float>> minMaxVals = new List<List<float>>();
            for (int attribute = 0; attribute < listOfData[0].Count; ++attribute) {
                minMaxVals.Add(findMinMaxVals(attribute));
            }
            //Random Centers between the Min and Max Vals of each column
            Random rand = new Random();
            for (int KRandomStarts = 0; KRandomStarts < k; ++KRandomStarts) {
                for (int attribute = 0; attribute < listOfData[0].Count; ++attribute) {
                    centers[KRandomStarts].Add((float)rand.Next((int)minMaxVals[attribute][0], (int)minMaxVals[attribute][1]));
                }
            }
            return centers;
        }

        /**
         * Finds the closes center point of all points using Euclidean Distance
         * */
        private void findAndSetEuclideanClosesCenter(List<List<float>> centers) {
            Dictionary<int, int> newWhatPoint = new Dictionary<int, int>();
            foreach (int point in whatPoint.Keys) {
                float bestDistance = float.MaxValue;
                int bestCenter = 0;
                for (int center = 0; center < centers.Count; ++center) {
                    float distance = 0;
                    for (int attributeRow = 0; attributeRow < centers[0].Count; ++attributeRow) {
                        distance += (float)Math.Pow(centers[center][attributeRow] - listOfData[point][attributeRow], 2);
                    }
                    distance = (float)Math.Sqrt(distance);
                    if (distance < bestDistance) {
                        bestDistance = distance;
                        bestCenter = center;
                    }
                }
                newWhatPoint[point] = bestCenter;
                //whatPoint[point] = bestCenter;
            }
            whatPoint = newWhatPoint;
        }

        /**
         * Finds and sets the ne center points based on the Center of Mass of 
         * the points asssigned to them
         * */
        private List<List<float>> findAndSetNewCenters(List<List<float>> center) {
            List<List<float>> centers = new List<List<float>>();
            for (int numberOfClusters = 0; numberOfClusters < center.Count; ++numberOfClusters) {
                centers.Add(new List<float>());
                for (int numOfAttributes = 0; numOfAttributes < listOfData[0].Count; ++numOfAttributes) {
                    centers[numberOfClusters].Add(0);
                }
            }
            List<int> centerTotalPoints = new List<int>();
            for (int i = 0; i < center.Count; ++i) {
                centerTotalPoints.Add(0);
            }

            foreach (int point in whatPoint.Keys) {
                for (int dimension = 0; dimension < listOfData[0].Count; ++dimension) {
                    float temp = listOfData[point][dimension];
                    centers[whatPoint[point]][dimension] += temp;
                }
                centerTotalPoints[whatPoint[point]] += 1;
            }
            for (int whatCenter = 0; whatCenter < centers.Count; ++whatCenter) {
                for (int dim = 0; dim < centers[0].Count; ++dim) {
                    centers[whatCenter][dim] /= ((centerTotalPoints[whatCenter] != 0) ? centerTotalPoints[whatCenter] : 1);
                }
            }
            return centers;
        }

        /**
         * Finds the Sum of Squared Error (SSE) of the given clusters
         * */
        private float findEuclideanDistance(int point, List<float> center) {
            float sse = 0;
            for (int attributes = 0; attributes < center.Count; ++attributes) {
                sse += (float)Math.Pow(listOfData[point][attributes] - center[attributes], 2);
            }
            return ((float)Math.Sqrt(sse));
        }

        /**
         * Finds the Sum of Squared Error (SSE) of the given clusters
         * */
        private float findSSE(List<List<float>> center) {
            float sse = 0;
            for (int kClusters = 0; kClusters < center.Count; ++kClusters) {
                for (int pointsInCluster = 0; pointsInCluster < whatPoint.Keys.Count; ++pointsInCluster) {
                    if (whatPoint[pointsInCluster] == kClusters) {
                        sse += (float)Math.Pow(findEuclideanDistance(pointsInCluster, center[kClusters]), 2);
                    }
                }
            }
            return sse;
        }

        /**
         * Does K-Means a few times to find the best K value by using different K values
         * */
        private int findBestK() {
            int bestK = 0;
            float bestSSE = float.MaxValue;
            float sse = 0;
            float ssePrev = float.MaxValue;
            float lastBestSSE = float.MaxValue;
            for (int kClusters = 2; kClusters <= (int)(listOfData.Count/2); ++kClusters) {
                List<List<float>> centers = createListOfCenters(kClusters);
                int numberOfIterations = 0;
                ssePrev = float.MaxValue;
                sse = 0;
                while((Math.Abs(ssePrev-sse) > 0.1) && numberOfIterations < 25) {
                    findAndSetEuclideanClosesCenter(centers);
                    centers = findAndSetNewCenters(centers);
                    ssePrev = sse;
                    sse = findSSE(centers);
                    numberOfIterations++;
                }
                if(bestSSE > sse) {
                    if (bestSSE != float.MaxValue) {
                        lastBestSSE = bestSSE;
                    }
                    bestK = kClusters;
                    bestSSE = sse;
                }
                if((bestSSE/lastBestSSE) > 0.7) {
                    break;
                }
            }
            return bestK;
        }


        private Dictionary<int,int> genericKMeans() {
            int k = findBestK(); //WHAT I SHOULD DO, IMPLEMENT LATER
            //int k = 5;
            float bestSSE = float.MaxValue;
            Dictionary<int, int> bestWhatPoint = new Dictionary<int, int>();
            List<List<float>> bestCenters = new List<List<float>>();
            List<List<float>> centers = new List<List<float>>();

            //For some number of iterations
            for (int kMeansIterations = 0; kMeansIterations < 50; ++kMeansIterations) {
                //Select initial seed points as prototype centers (at random) for the clusters
                centers = createListOfCenters(k);
                float ssePrev = float.MaxValue;
                float sse = 0;
                //Repeat:
                //Stop when the prototype does not move
                while((Math.Abs(ssePrev-sse)) > 0.1) {
                    //Assign all data points to the closest center
                    findAndSetEuclideanClosesCenter(centers);
                    //For each cluster formed, find the new prototype center for the center
                    centers = findAndSetNewCenters(centers);
                    ssePrev = sse;
                    sse = findSSE(centers);
                }
                if(bestSSE > sse) {
                    bestSSE = sse;
                    bestCenters = centers;
                    bestWhatPoint = whatPoint;
                }
            }
            return bestWhatPoint;
        }

        /**
         * Gets the problem clusters as a dictionary of {PID-Cluster#} pair
         * */
        public Dictionary<int,int> getProblemClusters() {
            Dictionary<int, int> bestWhatPoint = genericKMeans();
            Dictionary<int, int> problemCluster = new Dictionary<int, int>();
            int indexPID = 0;
            foreach (int key in bestWhatPoint.Keys) {
                problemCluster[PID[indexPID]] = bestWhatPoint[key];
                indexPID++; 
            }
            return problemCluster;
        } 
    }
}
