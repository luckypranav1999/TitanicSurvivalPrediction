# TitanicSurvivalPrediction
End-to-end Machine Learning Web Application predicting Titanic passenger survival probability. Includes ML model training (Logistic Regression), model serialization, .NET 8 Minimal API backend, Python inference, and real-time UI integration for live predictions.
🚢 Titanic Survival Prediction – End-to-End Machine Learning Web App
🎯 Project Goal

This project predicts the probability of a Titanic passenger surviving using a trained Machine Learning model deployed with a .NET 8 Minimal API and connected to a frontend UI for real-time prediction.

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

🏗 Architecture
                 ┌──────────────────────────┐
                 │  Frontend UI (HTML/CSS/JS)│
                 │  User inputs passenger data │
                 └──────────────┬─────────────┘
                                │ POST JSON
                                ▼
                     ┌────────────────────────┐
                     │  .NET 8 Minimal API     │
                     │  /api/predict endpoint  │
                     └──────────────┬──────────┘
                                    │ args
                                    ▼
                          ┌──────────────────────┐
                          │  Python (predict.py) │
                          │ Loads model.pkl       │
                          │ Predict + probability │
                          └───────────┬───────────┘
                                      │ JSON
                                      ▼
                         ┌──────────────────────────┐
                         │  Frontend displays result│
                         │  + probability bar       │
                         └──────────────────────────┘

🛠 Tech Stack
Layer	Technology
Machine Learning	Python, Pandas, Scikit-Learn, Joblib
Model Training	Jupyter Notebook
Backend	.NET 8 Minimal API
Frontend	HTML, CSS, JavaScript
Deployment	Local (Cloud deployment coming soon)
📁 Project Structure
📦 TitanicMLApp
├── UI.html                  # Frontend UI
├── Program.cs               # .NET backend API
├── predict.py               # Python inference script
├── titanic_model.pkl        # Trained ML model
├── Titanic.ipynb            # Model training notebook
└── README.md                # Documentation

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

