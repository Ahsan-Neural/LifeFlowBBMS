# 🩸 LifeFlowBBMS — Blood Bank Management System






> A complete desktop-based Blood Bank Management System built with Python and MySQL, designed to manage donors, patients, blood stock, requests, and reports — all in one place.

***

## 📋 Table of Contents

- [About](#about)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Modules](#modules)
- [Database Schema](#database-schema)
- [Screenshots](#screenshots)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Contributing](#contributing)

***

## 📖 About

**LifeFlowBBMS** is a Python + MySQL desktop application that automates the core operations of a blood bank. It replaces manual record-keeping with a fast, reliable, and user-friendly system. The project was developed as a Final Year Project (FYP) to solve real-world blood bank management challenges such as tracking blood availability, managing donor records, and processing patient requests efficiently.

***

## ✨ Features

- 🔐 Secure **Admin Login** system
- 👤 Full **Donor Registration** and management
- 🏥 **Patient Records** tracking
- 🩸 **Blood Stock** monitoring with real-time availability
- 📋 **Blood Request** processing (Approve / Reject)
- 🔬 **Blood Test** records management
- 📊 **Reports & Analytics** dashboard
- 🖥️ Clean and intuitive **GUI** built with Tkinter

***

## 🛠️ Tech Stack

| Technology | Purpose |
|------------|---------|
| **Python 3.x** | Core application logic |
| **Tkinter** | Desktop GUI framework |
| **MySQL** | Relational database |
| **mysql-connector-python** | Python–MySQL bridge |
| **Pillow (PIL)** | Image handling in GUI |

***

## 📦 Modules

### 1. 🔐 Login Module
Admin authentication with username and password validation against the database.

### 2. 👤 Donor Management
- Add, update, delete donor records
- Search donors by name, blood group, or ID
- View full donor history

### 3. 🏥 Patient Management
- Register new patients
- Track patient blood requirements
- View and manage patient records

### 4. 🩸 Blood Stock Management
- View current stock levels per blood group
- Automatic stock update on donation or request approval
- Low stock visibility

### 5. 📋 Blood Request Management
- Patients or staff submit blood requests
- Admin reviews, approves, or rejects requests
- Stock auto-decrements on approval

### 6. 🔬 Blood Test Management
- Record blood test results for donors
- Link test results to donor profiles

### 7. 📊 Reports & Analytics
- View donation history reports
- Blood usage statistics
- Exportable data summaries

***

## 🗄️ Database Schema

**Database Name:** `lifeflowbbms`

| Table | Description |
|-------|-------------|
| `admin` | Admin login credentials |
| `donors` | Donor personal and blood group info |
| `patients` | Patient records and requirements |
| `blood_stock` | Current stock per blood group (A+, A−, B+, B−, AB+, AB−, O+, O−) |
| `blood_requests` | Patient blood requests with status (Pending/Approved/Rejected) |
| `blood_tests` | Donor test results |
| `reports` | Generated reports and logs |

***

## 🚀 Installation

### Prerequisites

Make sure you have the following installed:

- [Python 3.x](https://www.python.org/downloads/)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)
- [MySQL Workbench](https://dev.mysql.com/downloads/workbench/) *(optional)*

### Step 1 — Clone the Repository

```bash
git clone https://github.com/YOUR_USERNAME/LifeFlowBBMS.git
cd LifeFlowBBMS
```

### Step 2 — Install Python Dependencies

```bash
pip install mysql-connector-python pillow
```

### Step 3 — Set Up the Database

1. Open MySQL Workbench or MySQL CLI
2. Run the following:

```sql
CREATE DATABASE lifeflowbbms;
USE lifeflowbbms;
```

3. Import the provided SQL file:

```bash
mysql -u root -p lifeflowbbms < database/lifeflowbbms.sql
```

### Step 4 — Configure Database Connection

Open `db_config.py` (or your connection file) and update:

```python
host     = "localhost"
user     = "root"
password = "your_mysql_password"
database = "lifeflowbbms"
```

### Step 5 — Run the Application

```bash
python main.py
```

***

## 🖥️ Usage

1. Launch the app with `python main.py`
2. Log in using Admin credentials
3. Navigate using the sidebar menu
4. Manage donors, patients, stock, and requests from their respective modules
5. Generate reports from the Reports section

**Default Admin Credentials:**
```
Username: admin
Password: admin123
```
*(Change these in the database after first login)*

***

## 📁 Project Structure

```
LifeFlowBBMS/
│
├── main.py                  # Application entry point
├── login.py                 # Login window
├── dashboard.py             # Main dashboard
├── donors.py                # Donor management module
├── patients.py              # Patient management module
├── blood_stock.py           # Blood stock module
├── blood_requests.py        # Blood request module
├── blood_tests.py           # Blood test module
├── reports.py               # Reports module
├── db_config.py             # Database connection config
│
├── database/
│   └── lifeflowbbms.sql     # Full database schema + seed data
│
├── assets/
│   └── images/              # UI images and icons
│
└── README.md
```

***

## 🤝 Contributing

Contributions are welcome! To contribute:

1. Fork the repository
2. Create a new branch: `git checkout -b feature/your-feature`
3. Commit your changes: `git commit -m "Add your feature"`
4. Push to the branch: `git push origin feature/your-feature`
5. Open a Pull Request

***

## 📄 License

This project is licensed under the **MIT License** — free to use, modify, and distribute.

***

## 👨‍💻 Author

**Ahsan** — Final Year Ai Student  


***

> *"Every drop counts. LifeFlowBBMS makes sure none is wasted."* 🩸
