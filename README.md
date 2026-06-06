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

**LifeFlowBBMS** is a comprehensive Windows desktop application built with **C# and WinForms** that streamlines blood bank operations. Designed for efficiency and ease of use, it replaces manual record-keeping with an automated, secure system.

This is a **University Final Year Project** demonstrating secure database management, user authentication, and business logic implementation for healthcare operations.

---

## ✨ Key Features

| Feature | Description |
|---------|-------------|
| 🔐 **Secure Authentication** | Admin login system with database-backed credentials and password hashing |
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
|-----------|----------|
| **Frontend** | C# WinForms |
| **Backend** | C# .NET Framework |
| **Database** | SQL Server / MySQL |
| **IDE** | Visual Studio 2022+ |
| **Language Version** | C# 10+ |
| **Security** | PBKDF2 Password Hashing, Parameterized Queries |

---

## 📦 Project Architecture

### Folder Structure

```
LifeFlowBBMS/
│
├── UI/                          # User interface forms and controls
│   ├── FrmLogin.cs              # Authentication interface
│   ├── FrmDashboard.cs          # Main application dashboard
│   ├── FrmDonorManagement.cs    # Donor management interface
│   ├── FrmBloodInventory.cs     # Blood inventory interface
│   ├── FrmBloodRequests.cs      # Request processing interface
│   ├── FrmReports.cs            # Analytics and reports
│   └── ...
│
├── DAL/                         # Data Access Layer
│   ├── ConnectionManager.cs     # Database connectivity
│   ├── InputValidator.cs        # Input validation utilities
│   ├── SecurityLogger.cs        # Audit and security logging
│   ├── DonorDAL.cs             # Donor data operations
│   └── ...
│
├── Models/                      # Data models and entities
│   └── ...
│
├── Logs/                        # Application logs (auto-generated)
│   └── *_YYYY-MM-DD.log
│
├── App.config                   # Application configuration (NEVER COMMIT)
├── App.config.example           # Configuration template
├── LifeFlowBBMS.csproj         # Project file
├── Program.cs                   # Application entry point
├── packages.config              # NuGet dependencies
├── LICENSE                      # MIT License
├── SECURITY_AUDIT_REPORT.md    # Security assessment document
└── README.md                    # This file
```

---

## 🎯 Core Modules

### 🔐 Authentication Module
- Secure admin login with PBKDF2 password hashing (SHA256, 100,000 iterations)
- Credential validation against database
- Session management
- Audit logging of login attempts
- Input validation on all authentication attempts

### 👤 Donor Management
- Add, update, and delete donor records
- Blood group classification and tracking
- Search and filter capabilities
- Input validation for phone, email, age ranges

### 🏥 Patient Management
- Patient registration and profile management
- Blood requirement tracking
- Medical history records
- Validated contact information

### 🩸 Blood Stock Management
- Real-time inventory for all blood types (A+, A−, B+, B−, AB+, AB−, O+, O−)
- Stock level monitoring and alerts
- Automatic stock updates on donations and requests
- Transaction logging for all inventory changes

### 📋 Blood Request Processing
- Request submission and tracking
- Admin approval/rejection workflow
- Automatic inventory deduction
- Audit trail for all modifications

### 📊 Reports & Analytics
- Donation statistics and trends
- Blood usage analytics
- Inventory reports
- Donor demographics

---

## 🚀 Getting Started

### Prerequisites

- **Windows Operating System** (Windows 7 or higher)
- **Visual Studio 2019+** (Community, Professional, or Enterprise)
- **.NET Framework 4.7.2+**
- **SQL Server 2016+** or **MySQL 5.7+**
- **Git** (for cloning the repository)

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
**IMPORTANT:** Never commit your database credentials to version control!

- Copy `App.config.example` to `App.config`
- Edit `App.config` and replace `YOUR_SERVER_NAME` with your SQL Server instance:

```xml
<connectionStrings>
    <add name="cn"
         connectionString="Data Source=YOUR_SERVER_NAME\SQLEXPRESS;Initial Catalog=LifeFlowBBMS;Integrated Security=True"
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

**Note:** The `App.config` file is in `.gitignore` to prevent accidental credential exposure.

#### 5. Build the Solution
- In Visual Studio: `Build` → `Build Solution` (Ctrl+Shift+B)
- Ensure no build errors

#### 6. Run the Application
- Press `F5` or click `Start` to launch the application
- Create your first admin account (see Initial Setup below)

---

## 🔐 Initial Setup & Security

### First Time Setup

1. **Launch the application**
2. **Create Initial Admin Account:**
   - You will be prompted to create an admin account on first launch
   - Choose a strong password (minimum 8 characters)
   - Requirements: uppercase, lowercase, numbers, special characters
3. **Database Setup:**
   - Ensure all database tables are created
   - SQL scripts available in `DatabaseScripts/` folder
4. **Test Login:**
   - Log in with your new admin credentials
   - Verify all modules are accessible

### Security Best Practices

⚠️ **BEFORE DEPLOYMENT:**
1. ✅ Change all default credentials
2. ✅ Update database connection settings in `App.config`
3. ✅ Enable SQL Server authentication encryption
4. ✅ Configure user roles and permissions
5. ✅ Test audit logging functionality
6. ✅ Set up regular database backups
7. ✅ Review log files regularly

**See `SECURITY_AUDIT_REPORT.md` for detailed security guidelines.**

---

## 📝 Usage Guide

1. **Launch Application** → Execute the compiled `.exe`
2. **Login** → Enter your admin credentials
3. **Navigate Dashboard** → Use menu to access modules
4. **Manage Data** → Add, edit, or delete records as needed
5. **Monitor Inventory** → Check blood stock levels regularly
6. **Generate Reports** → Create analytics and export data
7. **Review Logs** → Check audit logs for compliance
8. **Logout** → End your session securely

---

## 🗄️ Database Schema

**Database Name:** `lifeflowbbms`

| Table | Purpose |
|-------|----------|
| `Users` | All application users with roles |
| `Donors` | Donor personal information and blood group |
| `Patients` | Patient records and requirements |
| `BloodInventory` | Current inventory levels per blood type |
| `BloodRequests` | Blood requests with status tracking |
| `BloodTests` | Donor test results and health status |
| `BloodTransactions` | Transaction log for inventory changes |
| `AuditLog` | User actions and system events |

---

## 🛡️ Security Features

- ✅ **Password Security:** PBKDF2 hashing with SHA256 and random salt (100,000 iterations)
- ✅ **SQL Injection Prevention:** All queries use parameterized statements
- ✅ **Input Validation:** Comprehensive validation for all user inputs
- ✅ **Audit Logging:** Complete audit trail of user actions
- ✅ **Database Transactions:** ACID compliance for critical operations
- ✅ **Error Handling:** Secure error messages without information leakage
- ✅ **Logs Directory:** Auto-generated secure logging directory

**See `SECURITY_AUDIT_REPORT.md` for comprehensive security assessment.**

---

## 📊 Project Statistics

- **Language:** C# (100%)
- **Frameworks:** .NET Framework 4.7.2, WinForms
- **UI Forms:** 12+ for different operations
- **Database Tables:** 8+ core tables with relationships
- **Lines of Code:** 5000+ lines of secure code
- **Development:** University Final-Year Project

---

## 🤝 Contributing

We welcome contributions! Here's how:

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
5. **Open a Pull Request** with clear description

### Security Contributions
If you discover a security vulnerability:
1. **DO NOT** open a public issue
2. **Email** the maintainer with details
3. **Allow time** for fix before public disclosure

---

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

---

## 🚀 Future Enhancements

- [ ] Multi-user concurrent access
- [ ] Advanced reporting with charts
- [ ] Email notifications for stock alerts
- [ ] Blood type compatibility matrix
- [ ] Machine learning for demand forecasting
- [ ] Web portal for donors
- [ ] Mobile companion app
- [ ] Integration with hospital systems

---

## 📖 Documentation

- **[README.md](README.md)** - Project overview and setup
- **[SECURITY_AUDIT_REPORT.md](SECURITY_AUDIT_REPORT.md)** - Security assessment
- **[App.config.example](App.config.example)** - Configuration template
- **Inline Code Comments** - Throughout codebase

---

## 👨‍💻 Author

**Ahsan** — Final Year AI Student  
*Passionate about healthcare technology and software development*

**GitHub:** [Ahsan-Neural](https://github.com/Ahsan-Neural)

---

<div align="center">

**Made with ❤️ for better blood bank management**

> *"Every drop counts. LifeFlowBBMS ensures none is wasted." 🩸*

**[📋 Security Report](SECURITY_AUDIT_REPORT.md)** | **[🐛 Report Issues](https://github.com/Ahsan-Neural/LifeFlowBBMS/issues)** | **[⭐ Star the Project](https://github.com/Ahsan-Neural/LifeFlowBBMS)**

</div>
