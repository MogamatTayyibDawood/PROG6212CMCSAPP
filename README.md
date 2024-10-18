# Contract Monthly Claim System (CMCS)

## Overview

The **Contract Monthly Claim System (CMCS)** is a web-based application designed to assist contractors in submitting, tracking, and managing their monthly work claims. Users can easily submit their claims for hours worked, view their claim history, check the status of claims, and receive help and support through the application. 

This project is part of the Portfolio of Evidence (PoE) for the PROG6212 course.

---

## Table of Contents

- [Features](#features)
- [Technologies](#technologies)
- [Setup Instructions](#setup-instructions)
- [Usage](#usage)
- [Version Control Strategy](#version-control-strategy)
- [Contributing](#contributing)
- [License](#license)

---

## Features

- **Submit Claims**: Users can submit claims for the hours they have worked, along with the hourly rate.
- **View Claims**: Users can view all the claims they have submitted, including the status of each claim (pending, approved, rejected).
- **Help & Support**: A help section with FAQs and contact information for support.
- **Responsive UI**: A user-friendly and responsive interface for easy navigation.

---

## Technologies

- **Frontend**:
  - HTML5, CSS3, Bootstrap
  - JavaScript (jQuery)
- **Backend**:
  - ASP.NET Core MVC (C#)
- **Database**:
  - SQL Server (for claim data storage)
- **Version Control**:
  - Git and GitHub for version control

---

## Setup Instructions

Follow these steps to set up the CMCS application on your local machine:

### Prerequisites:

- .NET SDK 6.0+
- Visual Studio or any C# IDE
- SQL Server (LocalDB or any SQL version)

### Steps:

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/MogamatTayyibDawood/PROG6212CMCSAPP.git
   cd PROG6212CMCSAPP
   ```

2. **Open the Solution**:
   - Open the `PROG6212CMCSAPP.sln` file in Visual Studio.

3. **Set up the Database**:
   - Run the SQL Server and apply migrations if any (create necessary tables).

4. **Run the Application**:
   - Use Visual Studio's debug option or run `dotnet run` from the terminal to start the application.

5. **Access the Application**:
   - Open a web browser and navigate to `http://localhost:5000`.

---

## Usage

### Submit a Claim:

1. Navigate to the **Submit Claim** page.
2. Enter the hours worked, the hourly rate, and upload any supporting documents.
3. Click on **Submit** to send the claim for approval.

### View Your Claims:

- Navigate to **View Claims** to see a list of your submitted claims, their status, and details like hours worked and total amount.

### Help & Support:

- Go to **Help & Support** for FAQs or contact the support team via email.

---

## Version Control Strategy

The project follows a strict version control strategy using Git and GitHub:

1. **Commit and Push to GitHub Repo**:
   - All code changes are committed and pushed regularly to the GitHub repository: `https://github.com/your-username/PROG6212CMCSAPP`.

2. **Descriptive Commit Messages**:
   - Each commit has a descriptive message summarizing the changes made. For example:
     - `feat: Added functionality for submitting claims`
     - `fix: Corrected alignment issues in the claim form`

3. **Regular Updates**:
   - The repository is updated frequently with at least 5 meaningful commits during development, ensuring consistent progress and version tracking.

---

## Contributing

1. Fork the repository.
2. Create a new feature branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/your-feature`).
5. Open a pull request.

---

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

### Contact

If you need help with the system, feel free to contact the support team at `support@cmcsapp.com`.

---

