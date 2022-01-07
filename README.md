# ContactBook App
ContactBook is a simple dotnet desktop application to browse, add, and delete contacts. It uses the WPF as UI framework and JSON file as a database to store and retrieve the contact from it. The used architectural pattern for the UI is MVVM pattern. 

## Project Structure:
The project consists of two major parts, **ContactBook.Data** and **ContactBook.WPF**.
- **ContactBook.Data**:
  - *Console Application* as it has a helper class to generate mock JSON DB file.
  - Contains the main models (contact.cs), and validation.
- **ContactBook.WPF**:
  - Contains the service that calls the DB to read and write the data.
  - Contains Views, ViewModels.

## Project Key Points:
- ### Client Service (ContactBook.Data):
  - Use JSON file as a database to read and write the contacts
  - Use Repository pattern as a design pattern to allow replacing the database on the future form JSON file to an actual database
  - Implement async in reading and writing the data
- ### Client-Side (ContactBook.WPF):
  -  The used framework is WPF
  -  Use MVVM pattern as an architectural pattern:
      - No code-behind
      - Use commands and behaviors to communicate between views and viewmodels
      - Separate the views responsibilities from viewmodels, and models responsibilities
  - Implement data validation using Data Annotations, and INotifyDataErrorInfo interface
  - Adding searching and filtering to the contacts

## Dependensies:
- Newtonsoft.Json (Version 13.0.0.0)
- Microsoft.Xaml.Behaviors (Version 1.1.0.0)

## Running the Project:
1. Download, and build the projects.
2. Run "ContactBook.Data" to generate the JSON file that works as the DB
3. You can now Run "ContactBook.WPF" to launch the ContactBook desktop application 
