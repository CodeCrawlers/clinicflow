# Clinicflow

ClinicFlow is a backend-oriented project designed to simulate and manage the core operations of a clinical environment. The system is built using ASP.NET and Entity Framework Core, with a SQL Server database, following a code-first approach.

The main goal of this project is to provide a structured and scalable foundation for handling clinical data such as patients, and to progressively extend it with additional entities like doctors, appointments, and medical records.

## Overview

The current implementation focuses on patient management. It includes a fully functional REST API that allows creating, retrieving, updating, and deleting patient records. All data is persisted in a relational database, and the API communicates with it through Entity Framework Core.

This project is structured to reflect a layered architecture, separating concerns between domain logic, application logic, infrastructure, and API endpoints. This approach makes the system easier to maintain and extend as new features are introduced.

## Features (current progress)

- Patient management with full CRUD operations  
- Integration with SQL Server using Entity Framework Core  
- Code-first database design with migrations  
- Clean project structure with separation of concerns  
- HTTP endpoint testing using `.http` files  

## Technologies

- ASP.NET Core  
- Entity Framework Core  
- SQL Server (LocalDB)  
- C#  

## Project Structure (current progress)

The solution is organized into multiple layers:

- **ClinicFlow.API** – Handles HTTP requests and exposes endpoints  
- **ClinicFlow.Application** – Contains application logic  
- **ClinicFlow.Domain** – Defines core entities and business rules  
- **ClinicFlow.Infrastructure** – Manages data access and database configuration  

This structure allows the project to scale while keeping responsibilities clearly defined.

## Current Status

The system currently supports patient management and database integration. Future improvements will include additional entities such as doctors and appointments, as well as relationships between them to better represent real-world clinical workflows.

## Purpose

This project is intended as both a learning experience and a foundation for building more advanced backend systems. It focuses on practical implementation of common patterns used in modern web development, including RESTful APIs, database integration, and layered architecture.

---

By Adrián Quirós and Fabián Gamboa (SaintVICode and YotsubaFutureSE)
