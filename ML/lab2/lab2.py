import pandas as pd
import numpy as np
from sklearn.impute import SimpleImputer
from sklearn.linear_model import LinearRegression
import matplotlib.pyplot as plt

import numpy as np

import numpy as np

def remove_anomalies_deviation(X, y, num_std_x=3, num_std_y=2):
    """
    Removes data points that are more than num_std standard deviations away from the mean.
    Returns the filtered X and y arrays.
    """
    # Compute the mean and standard deviation of the data
    X_mean, X_std = np.mean(X), np.std(X)
    y_mean, y_std = np.mean(y), np.std(y)
    
    # Filter out data points that are more than num_std standard deviations away from the mean
    mask = (X >= X_mean - num_std_x*X_std) & (X <= X_mean + num_std_x*X_std)
    mask = mask & (y >= y_mean - num_std_y*y_std) & (y <= y_mean + num_std_y*y_std)
    X_filtered = X[mask]
    y_filtered = y[mask]
    
    return X_filtered, y_filtered

def remove_anomalies_bounds_check(X, y, price_range=(1000, 100000), mileage_range=(0, 300000)):
    """
    Removes data points that fall outside the specified price and mileage ranges.
    Returns the filtered X and y arrays.
    """
    # Filter out data points that fall outside the specified price and mileage ranges
    mask = (X >= price_range[0]) & (X <= price_range[1]) & (y >= mileage_range[0]) & (y <= mileage_range[1])
    X_filtered = X[mask]
    y_filtered = y[mask]
    
    return X_filtered, y_filtered




# Load the data from the CSV file
data = pd.read_csv('lab2/data_cars.csv')

# Check for missing data
if data.isnull().values.any():
    # Impute missing values using mean imputation
    imputer = SimpleImputer(strategy='mean')
    data[['Mileage', 'Price']] = imputer.fit_transform(data[['Mileage', 'Price']])

# Extract the features (mileage) and target (price) from the data
x = data['Mileage'].values
y = data['Price'].values

data = remove_anomalies_deviation(data['Price'].values, data['Mileage'].values)
# data = remove_anomalies_bounds_check(data['Price'].values, data['Mileage'].values)

# Reshape the data into a 2D array
x = data[0].reshape(-1, 1)
y = data[1].reshape(-1, 1)

# Create a linear regression model and fit it to the data
model = LinearRegression()
model.fit(x, y)

# Predict the price of a car with 50,000 miles
mileage = np.array([[50000]])
predicted_price = model.predict(mileage)

print('Predicted price for a car with 50000 mileage: ${:,.2f}'.format(predicted_price[0][0]))

# Plot the data points and the regression line
plt.scatter(x, y, color='blue', s=1)
plt.plot(x, model.predict(x), color='red', linewidth=2)
plt.xlabel('Mileage')
plt.ylabel('Price')
plt.title('Linear Regression')
plt.show()