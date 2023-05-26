import pandas as pd
import numpy as np
from sklearn.impute import SimpleImputer
from sklearn.linear_model import LinearRegression
import matplotlib.pyplot as plt

# Load the data from the CSV file
data = pd.read_csv('lab2/data_cars.csv')

# Check for missing data
if data.isnull().values.any():
    # Impute missing values using mean imputation
    imputer = SimpleImputer(strategy='mean')
    data[['Mileage', 'Price']] = imputer.fit_transform(data[['Mileage', 'Price']])

# Extract the features (mileage) and target (price) from the data
X = data['Mileage'].values.reshape(-1, 1)
y = data['Price'].values

# Create a linear regression model and fit it to the data
model = LinearRegression()
model.fit(X, y)

# Predict the price of a car with 100,000 miles
mileage = [[1000000]]
predicted_price = model.predict(mileage)

# Plot the data points and the regression line
plt.scatter(X, y, color='blue')
plt.plot(X, model.predict(X), color='red', linewidth=2)
plt.xlabel('Mileage')
plt.ylabel('Price')
plt.title('Linear Regression')
plt.show()