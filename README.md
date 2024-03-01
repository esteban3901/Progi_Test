# Progi_Test

Application that will allow a buyer to calculate the total price of a vehicle at a car auction. The buyer must pay various fees for the transaction, all of which are calculated on the base price amount. The total amount calculated is the winning bid amount (vehicle base price) plus the fees based on the vehicle price and vehicle type.
The app provide the business logic to calcute all fees.

## Requirements

- [Node.js](https://nodejs.org/) (to run the VueJS frontend)
- [Vue CLI](https://cli.vuejs.org/) (optional but recommended for VueJS development)
- [.NET Core SDK](https://dotnet.microsoft.com/download) (to run the C# backend)

## Setup

### Backend (C# Web API)

1. Clone or download this repository.
2. Navigate to the backend folder: 'cd Progi_Test_Back'.
3. Run 'dotnet build' to build the project.
4. Run 'dotnet run' to start the server.
5. The backend will be available at 'http://localhost:5188'.
6. Navigate to url 'http://localhost:5188/swagger' to test the endpoint indivdually.

### Frontend (VueJS)

1. Navigate to the frontend folder: 'cd frontend'.
2. Install dependencies: 'npm install'.
3. Start the development server: 'npm run serve'.
4. The frontend will be available at 'http://localhost:8080' by default. IMPORTANT: If your IDE provides you another port, go to the url provided by your IDE.

## Usage

In the frontend view of the application, there is a text box provided to enter the base value of the vehicle and a dropdown to choose the type of vehicle. This data will be automatically sent to the backend API for calculating the taxes (fees) and the total value.

Upon receiving the response, it will be automatically reflected in the table located below.

## License

No license. This is a repository to delivery a request in a technical challenge.

## Contact

If you have any questions or suggestions, feel free to contact the developer via email to: estebanparra15@gmail.com.
