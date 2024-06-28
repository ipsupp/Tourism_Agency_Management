// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using ServerApp.repository;
using ServerApp;
using ServerApp.service;

SqlConnection cnn;
// Get path to the project
string localProjectPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));
CurrentAppData.connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"{localProjectPath}\\MainDB.mdf\";Integrated Security=True;Connect Timeout=30";
cnn = new SqlConnection(CurrentAppData.connectionString);
cnn.Open();
AgencyRepository agencyRepository = new AgencyRepository(cnn);
EmployeeRepository employeeRepository = new EmployeeRepository(cnn);
TCompanyRepository companyRepository = new TCompanyRepository(cnn);
TripRepository tripRepository = new TripRepository(cnn);
ReservationRepository reservationRepository = new ReservationRepository(cnn);

Service service = new Service(agencyRepository, employeeRepository, companyRepository, tripRepository, reservationRepository);
service.RunAsync();