# 🩸 LifeFlowBBMS
## Blood Bank Management System

<div align="center">

**A modern desktop application for comprehensive blood bank operations management**

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Language: C#](https://img.shields.io/badge/Language-C%23-239120?logo=csharp)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![Platform: Windows](https://img.shields.io/badge/Platform-Windows-0078D4?logo=windows)](https://www.microsoft.com/windows)

</div>

---

## 📖 About

**LifeFlowBBMS** is a comprehensive Windows desktop application built with **C# and WinForms** that streamlines blood bank operations. Designed for efficiency and ease of use, it replaces manual record-keeping with an automated system to manage donors, patients, blood inventory, requests, and critical reports—all in one integrated platform.

---

## ✨ Key Features

| Feature | Description |
|---------|-------------|
| 🔐 **Secure Authentication** | Admin login system with database-backed credentials |
| 👤 **Donor Management** | Register, update, and track donor information and blood groups |
| 🏥 **Patient Records** | Maintain comprehensive patient profiles and medical history |
| 🩸 **Blood Stock Management** | Real-time inventory tracking across all blood types |
| 📋 **Blood Requests** | Process, approve, and reject blood requests efficiently |
| 🔬 **Blood Testing** | Manage donor blood test results and compatibility checks |
| 📊 **Reports & Analytics** | Generate detailed reports and usage statistics |
| 🖥️ **User-Friendly Interface** | Intuitive WinForms GUI for seamless navigation |

---

## 🛠️ Technology Stack

| Component | Technology |
|-----------|-----------|
| **Frontend** | C# WinForms |
| **Backend** | C# .NET Framework |
| **Database** | SQL Server / MySQL |
| **IDE** | Visual Studio 2022+ |
| **Language Version** | C# 10+ |

---

## 📦 Project Architecture

### Folder Structure

```
LifeFlowBBMS/
│
├── UI/                          # User interface forms and controls
│   ├── LoginForm.cs             # Authentication interface
│   ├── DashboardForm.cs         # Main application dashboard
│   ├── DonorManagementForm.cs   # Donor management interface
│   ├── PatientManagementForm.cs # Patient management interface
│   ├── BloodStockForm.cs        # Blood inventory interface
│   ├── BloodRequestForm.cs      # Request processing interface
│   ├── ReportsForm.cs           # Analytics and reports
│   └── ...
│
├── DAL/                         # Data Access Layer
│   ├── DatabaseConnection.cs    # Database connectivity
│   ├── DonorDAL.cs             # Donor data operations
│   ├── PatientDAL.cs           # Patient data operations
│   ├── BloodStockDAL.cs        # Inventory operations
│   └── ...
│
├── Models/                      # Data models and entities
│   ├── Donor.cs
│   ├── Patient.cs
│   ├── BloodStock.cs
│   ├── BloodRequest.cs
│   └── ...
│
├── App.config                   # Application configuration
├── LifeFlowBBMS.csproj         # Project file
├── Program.cs                   # Application entry point
├── packages.config              # NuGet dependencies
├── LICENSE                      # MIT License
└── README.md                    # This file
```

---

## 🎯 Core Modules

### 🔐 Authentication Module
- Secure admin login with credential validation
- Password-protected access to all features
- Session management

### 👤 Donor Management
- Add, update, and delete donor records
- Blood group classification and tracking
- Search and filter capabilities
- Donor history and donation records

### 🏥 Patient Management
- Patient registration and profile management
- Blood requirement tracking
- Medical history records
- Emergency contact information

### 🩸 Blood Stock Management
- Real-time inventory for all blood types (A+, A−, B+, B−, AB+, AB−, O+, O−)
- Stock level monitoring and alerts
- Automatic stock updates on donations and requests
- Expiry date tracking

### 📋 Blood Request Processing
- Request submission and tracking
- Admin approval/rejection workflow
- Automatic inventory deduction
- Request status notifications

### 🔬 Blood Testing
- Test result recording and management
- Donor health status tracking
- Compatibility verification
- Test history reports

### 📊 Reports & Analytics
- Donation statistics and trends
- Blood usage analytics
- Inventory reports
- Donor demographics
- Exportable data summaries

---

## 🚀 Getting Started

### Prerequisites

- **Windows Operating System** (Windows 7 or higher)
- **Visual Studio 2019+** (Community, Professional, or Enterprise)
- **.NET Framework 4.7.2+**
- **SQL Server 2016+** or **MySQL 5.7+**

### Installation Steps

#### 1. Clone the Repository
```bash
git clone https://github.com/Ahsan-Neural/LifeFlowBBMS.git
cd LifeFlowBBMS
```

#### 2. Open in Visual Studio
- Launch Visual Studio
- Open the solution file: `LifeFlowBBMS.slnx`

#### 3. Install Dependencies
- NuGet packages are listed in `packages.config`
- Visual Studio will automatically restore them, or run:
```bash
nuget restore
```

#### 4. Configure Database Connection
Edit the connection string in `App.config`:
```xml
<connectionStrings>
    <add name="BBMSConnection" 
         connectionString="Server=YOUR_SERVER;Database=lifeflowbbms;User Id=YOUR_USER;Password=YOUR_PASSWORD;" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

#### 5. Build the Solution
- In Visual Studio: `Build` → `Build Solution` (Ctrl+Shift+B)
- Ensure no build errors

#### 6. Run the Application
- Press `F5` or click `Start` to launch the application
- Login with default credentials (configured in your database)

---

## 📝 Usage Guide

1. **Launch Application** → Execute the compiled `.exe`
2. **Login** → Enter admin credentials
3. **Navigate Dashboard** → Use menu to access modules
4. **Manage Data** → Add, edit, or delete records as needed
5. **Generate Reports** → Create analytics and export data
6. **Logout** → End your session securely

---

## 🔐 Default Credentials

> ⚠️ **Important**: Change these credentials immediately after first login

| Field | Value |
|-------|-------|
| **Username** | admin |
| **Password** | admin123 |

---

## 🗄️ Database Schema

**Database Name:** `lifeflowbbms`

| Table | Purpose |
|-------|---------|
| `Admin` | Administrator login credentials |
| `Donors` | Donor personal information and blood group |
| `Patients` | Patient records and requirements |
| `BloodStock` | Current inventory levels per blood type |
| `BloodRequests` | Blood requests with status tracking |
| `BloodTests` | Donor test results and health status |
| `Reports` | Generated reports and logs |

---

## 🤝 Contributing

We welcome contributions! Here's how to contribute:

1. **Fork** the repository
2. **Create a feature branch**
   ```bash
   git checkout -b feature/YourFeatureName
   ```
3. **Commit your changes**
   ```bash
   git commit -m "Add: Your feature description"
   ```
4. **Push to the branch**
   ```bash
   git push origin feature/YourFeatureName
   ```
5. **Open a Pull Request** with a clear description

---

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

---

## 👨‍💻 Author

**Ahsan** — Final Year AI Student  
*Passionate about healthcare technology and software development*

---

<div align="center">

**Made with ❤️ for better blood bank management**

> *"Every drop counts. LifeFlowBBMS ensures none is wasted." 🩸*

</div>