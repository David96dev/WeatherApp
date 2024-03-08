# Weather Site Project

## Description

## Table of Contents

- [Overview](#overview)
- [Authors](#authors)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [MVC Structure](#mvc-structure)
- [Contributing](#contributing)
- [License](#license)

## Overview
This project is aimed at developing a weather site that allows users to search for weather information for different cities around the world. 
Users will also have the option to retrieve weather information based on their current location. 
The project utilizes the OpenWeatherAPI for weather data retrieval and integrates Google Maps API for location services. 
The site follows the MVC (Model-View-Controller) architecture for better organization and maintainability.


## Authors

- David
- Yassine

## Features
- Search weather information for different cities.
- Retrieve weather information based on current location.
- Integration with OpenWeatherAPI for weather data.
- Integration with Google Maps API for location services.
- MVC architecture for structured development.
- User authentication for security.

## Installation
-Clone the repository: git clone https://github.com/your-repository.git
-Install dependencies: npm install
-Set up environment variables:
-Create a .env file in the root directory.
-Add the following variables:
-makefile
-OPENWEATHER_API_KEY=your_openweather_api_key
-GOOGLE_MAPS_API_KEY=your_google_maps_api_key

## Usage
-Start the server: npm start
-Access the site through the provided URL.
-Register/Login to access the weather features.
-Use the search bar to search for weather information by city name.
-Use the "Current Location" option to retrieve weather information based on your current location.

## MVC Structure
The project follows the MVC architecture for better organization and separation of concerns.

Models: Handle data logic and database interactions.
Views: Present data to the user and handle user interface components.
Controllers: Handle user input and interaction, and manage communication between models and views.

