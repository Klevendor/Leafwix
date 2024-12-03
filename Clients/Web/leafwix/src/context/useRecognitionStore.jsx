import {create} from 'zustand';

const useRecognitionStore = create((set) => ({
    fileSelected: null,
    predictedLabel: null,
    predictionConfidence: null,
    plant_age: 0,
    
    setPlantAge: (age) => set({
      plant_age:age
    }),

    setFileSelected: (newImage) => set({
        fileSelected: newImage,
      }),

    setRecognitionResult: (label, confidence) => set({
      predictedLabel: label,
      accuracy: confidence,
    }),

    setNewPredictedLabel: (label, confidence) => set({
      predictedLabel: label
    }),
  
    reset: () => set({
      fileSelected: false,
      predictedLabel: false,
      predictionConfidence: null
    }),
  }));


export default useRecognitionStore;