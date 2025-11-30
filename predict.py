import sys
import joblib
import pandas as pd
import json

# Load trained model
model = joblib.load("titanic_model.pkl")

# CLI args from C#:
Pclass = int(sys.argv[1])
Sex = sys.argv[2]
Age = float(sys.argv[3])
SibSp = int(sys.argv[4])
Parch = int(sys.argv[5])
Fare = float(sys.argv[6])
Embarked = sys.argv[7]

# Map to encoded features from training:
male = 1 if Sex.lower() == "male" else 0
Q = 1 if Embarked == "Q" else 0
S = 1 if Embarked == "S" else 0   # C = 0,0

df = pd.DataFrame([{
    "Pclass": Pclass,
    "Age": Age,
    "SibSp": SibSp,
    "Parch": Parch,
    "Fare": Fare,
    "male": male,
    "Q": Q,
    "S": S
}])

prediction = model.predict(df)[0]
probability = model.predict_proba(df)[0][1]

result = {
    "result": "Survived" if prediction == 1 else "Not Survived",
    "probability": round(float(probability) * 100, 2)
}

print(json.dumps(result))
