# Butterfly Systems Evaluation - Calculator
A calculator that performs simple operation (+/-/*/%) on two numbers. This project is powered by .Net Core 3.1 and Vue 3.

## Directory Structure
* API - .Net Core 3.1 WebAPI
* Client - Vue 3

## Requirements
* Node 8.9+
* Yarn or NPM
* [.Net Core 3.1 Runtime](https://dotnet.microsoft.com/download/dotnet-core/3.1)

## Usage
1. Clone/checkout and change to the directory:
```
cd butterfly-systems-calculator
```
2. In the API directory launch the .Net Core 3.1 Kestrel server by typing the following commands
```
cd API
dotnet run
```
3. In another terminal window, install the necessary node packages by typing the following commands in the Client directory
```
cd Client
yarn install
```
or
```
npm install
```
4. Run the transpiler to serve the application
```
yarn serve
```
or
```
npm run serve
```
5. Access the application via http://localhost:8080/ in your web browser of choice 🙂