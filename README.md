# 🚢 Titanic Survival Prediction | ML + .NET + Python + Web UI

This project predicts whether a passenger would survive the Titanic disaster using a Machine Learning model built with **Logistic Regression**.  
The solution includes:

- 🧠 **ML Model** trained on Titanic dataset (Kaggle)
- 🐍 **Python backend script** with joblib model loading
- 🌐 **.NET Minimal API** to execute Python & return predictions
- 💻 **HTML + JS Frontend UI** to collect input and display result
- 🔗 **Full end-to-end integration** using `fetch()` + CORS


Unlike typical Titanic ML notebooks, this project demonstrates full production-style deployment:

ML model training

Model serialization & inference

API layer

Frontend integration

Live prediction with probability and visualization

🧠 Key Features

✔ Logistic Regression ML Model trained on Kaggle Titanic dataset
✔ Real-time prediction & probability output
✔ Feature engineering (male, Q, S encoding)
✔ .NET API calling Python inference using ProcessStartInfo
✔ Elegant frontend UI with probability bar and colored result card
✔ End-to-end system like real production ML deployment

Architecture:
HTML/JavaScript Frontend → sends POST request → .NET Minimal API → triggers Python script → loads ML model (.pkl) → performs prediction & probability → returns JSON response → UI displays result

🛠 Tech Stack
Layer	Technology
Machine Learning	Python, Pandas, Scikit-Learn, Joblib
Model Training	Jupyter Notebook
Backend	.NET 8 Minimal API
Frontend	HTML, CSS, JavaScript
Deployment	Local (Cloud deployment coming soon)
📁 Project Structure
TitanicSurvivalPrediction/
│
├── TitanicAPI/
│   ├── Program.cs              # .NET Backend API
│   ├── predict.py              # Python ML execution script
│   ├── titanic_model.pkl       # Saved ML model
│   ├── Titanic.ipynb           # Notebook used for training
│   ├── UI.html                 # Frontend
│   ├── ...
│
└── README.md


📌 UI Interface – Prediction Form
📌 Prediction Output – Probability bar
📌 Backend API & Console logs


📊 Model Training

Selected features:

["Pclass", "Age", "SibSp", "Parch", "Fare", "male", "Q", "S"]


Model:

logmodel = LogisticRegression(max_iter=500)
logmodel.fit(X, y)
joblib.dump(logmodel, "titanic_model.pkl")

💡 Example Prediction Output
{
  "result": "Survived",
  "probability": 87.34
}

🏁 Run Instructions
Start Backend
dotnet run --urls "http://127.0.0.1:5224"

Run UI (Live Server or HTTP server)
http://127.0.0.1:5500/UI.html

Interaction Flow

Enter passenger info

Click Predict

Backend calls Python → returns JSON

UI displays visual result

