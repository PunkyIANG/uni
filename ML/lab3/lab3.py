import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from sklearn.cluster import KMeans, DBSCAN
from scipy.cluster.hierarchy import dendrogram, linkage

def elbow_method(X, max_clusters=10):
    """
    Computes the within-cluster sum of squares (WCSS) for different values of k,
    and returns the optimal number of clusters using the elbow method.
    """
    wcss = []
    for i in range(1, max_clusters+1):
        kmeans = KMeans(n_clusters=i, init='k-means++', max_iter=300, n_init=10, random_state=0)
        kmeans.fit(X)
        wcss.append(kmeans.inertia_)
    
    # Compute the first derivative of the WCSS curve
    first_deriv = np.gradient(wcss)
    
    # Compute the second derivative of the WCSS curve
    second_deriv = np.gradient(first_deriv)
    
    # Find the index of the elbow point
    elbow_index = np.argmax(second_deriv) + 1

    plt.plot(range(1, 11), wcss)
    plt.title('Elbow Method')
    plt.xlabel('Number of clusters')
    plt.ylabel('WCSS')
    plt.show()
    
    return int(elbow_index)

def kmeans_clustering(X, n_clusters=3):
    # Apply k-means clustering with the optimal number of clusters
    kmeans = KMeans(n_clusters, init='k-means++', max_iter=300, n_init=10, random_state=0)
    y_kmeans = kmeans.fit_predict(X)

    # Visualize the clusters
    plt.scatter(X[y_kmeans == 0, 0], X[y_kmeans == 0, 1], s = 100, c = 'red', label = 'Iris-setosa')
    plt.scatter(X[y_kmeans == 1, 0], X[y_kmeans == 1, 1], s = 100, c = 'blue', label = 'Iris-versicolour')
    plt.scatter(X[y_kmeans == 2, 0], X[y_kmeans == 2, 1], s = 100, c = 'green', label = 'Iris-virginica')
    plt.scatter(kmeans.cluster_centers_[:, 0], kmeans.cluster_centers_[:, 1], s = 300, c = 'yellow', label = 'Centroids')
    plt.title('Clusters of Iris')
    plt.xlabel('Sepal length')
    plt.ylabel('Sepal width')
    plt.legend()
    plt.show()

    return y_kmeans

def hierarchical_clustering(X, method='ward', metric='euclidean'):
    """
    Performs hierarchical clustering on the input data X using the specified method and metric.
    Returns the linkage matrix and the dendrogram plot.
    """
    # Compute the linkage matrix
    Z = linkage(X, method=method, metric=metric)
    
    # Plot the dendrogram
    plt.figure(figsize=(10, 5))
    dendrogram(Z)
    plt.title('Hierarchical Clustering Dendrogram')
    plt.xlabel('Sample Index')
    plt.ylabel('Distance')
    plt.show()
    
    return Z


def dbscan_clustering(X, eps=0.5, min_samples=5):
    """
    Performs DBSCAN clustering on the input data X using the specified eps and min_samples parameters.
    Returns the cluster assignments.
    """
    dbscan = DBSCAN(eps=eps, min_samples=min_samples)
    y_dbscan = dbscan.fit_predict(X)

    # Visualize the clusters
    plt.scatter(X[y_dbscan == -1, 0], X[y_dbscan == -1, 1], s = 100, c = 'black', label = 'Noise')
    plt.scatter(X[y_dbscan == 0, 0], X[y_dbscan == 0, 1], s = 100, c = 'red', label = 'Cluster 1')
    plt.scatter(X[y_dbscan == 1, 0], X[y_dbscan == 1, 1], s = 100, c = 'blue', label = 'Cluster 2')
    plt.scatter(X[y_dbscan == 2, 0], X[y_dbscan == 2, 1], s = 100, c = 'green', label = 'Cluster 3')
    plt.title('Clusters of Iris')
    plt.xlabel('Sepal length')
    plt.ylabel('Sepal width')
    plt.legend()
    plt.show()
    
    return y_dbscan

# Load the iris dataset
data = pd.read_csv('lab3/iris.data', header=None, names=['sepal_length', 'sepal_width', 'petal_length', 'petal_width', 'class'])
X = data.iloc[:, :-1].values

# cluster_count = elbow_method(X)
cluster_count = 3
kmeans_clustering(X, cluster_count)

# hierarchical_clustering(X)

# dbscan_clustering(X)