# ContactBook Desktop App
ContactBook is a simple dotnet desktop application to browse, add, and delete contacts. It uses the WPF as UI framework and JSON file as a database to store and retrieve the contact from it. The used architectural pattern for the UI is MVVM pattern. 

## External Packages:
- Newtonsoft.Json (Version 13.0.0.0)
- Microsoft.Xaml.Behaviors (Version 1.1.0.0)

## Project Structure:
- ### Client Service
  - Use JSON file as a database to read and write the contacts
  - Use Repository pattern as a design pattern to allow replacing the database on the future form JSON file to actual database
  - Implement async in reading and writing the data
- ### Client Side:
  -  The used framework is WPF
  -  Use MVVM pattern as an architectural pattern:
      - No code behine
      - Use commands and behaviors to communicate between views and viewmodels
      - Seperate the view resposability from viewmodels responsabilities
  - Implement data validation using Data Annotations, and INotifyDataErrorInfo interface
  - Adding searching and filtering to the contacts
