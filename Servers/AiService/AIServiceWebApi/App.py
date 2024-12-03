from fastapi import FastAPI, Body
from fastapi.middleware.cors import CORSMiddleware
from fastapi import FastAPI, File, UploadFile
from fastapi.responses import JSONResponse
from PIL import Image
import numpy as np
import tensorflow as tf
from io import BytesIO


app = FastAPI()

app.add_middleware(
    CORSMiddleware,
    allow_origins=[
        "http://localhost:5173",
        "http://localhost:5294"
        ],
    allow_methods=["*"],
    allow_headers=["*"],
    allow_credentials=True
)

model = tf.keras.models.load_model("./AIServiceDAL/ModelsAI/plants47_model.keras")

indices_to_labels = {
    0: 'African Violet (Saintpaulia ionantha)',
    1: 'Aloe Vera',
    2: 'Cast Iron Plant (Aspidistra elatior)',
    3: 'Chinese evergreen (Aglaonema)',
    4: 'Ctenanthe',
    5: 'Dracaena',
    6: 'Kalanchoe',
    7: 'Lilium (Hemerocallis)',
    8: 'Pothos (Ivy arum)',
    9: 'Rubber Plant (Ficus elastica)'
}

def preprocess_image(image: Image):
    # Перетворення зображення в потрібний формат для моделі
    image = image.resize((224, 224))  # Зміна розміру зображення (потрібно відповідно до вимог моделі)
    image_array = np.array(image)  # Перетворення в масив NumPy
    image_array = np.expand_dims(image_array, axis=0)  # Додаємо ще один вимір для партії
    image_array = image_array / 255.0  # Нормалізація (залежно від вимог моделі)
    return image_array

@app.get("/")
async def root():
    return {"message": "FastAPI Server was started!"}


@app.put("/plant-recognize")
async def recognize_plant(image: UploadFile = File(...)):
    print("Ok Put is works")
    try:
        print("Received image for recognition.")
        image_bytes = await image.read()
        image = Image.open(BytesIO(image_bytes))  # Відкриваємо зображення з байтів
        
        processed_image = preprocess_image(image)
        
        prediction = model.predict(processed_image)
        predicted_class_index = np.argmax(prediction, axis=1)[0]
        
        predicted_label = indices_to_labels.get(predicted_class_index, "Unknown plant")

        return JSONResponse(content={
            "predicted_class": predicted_label,
            "prediction_confidence": float(np.max(prediction))
        })
    
    except Exception as e:
        return JSONResponse(status_code=500, content={"message": f"Error processing image: {str(e)}"})
