import time
import threading
import cv2
import numpy as np
from datetime import datetime
import pymysql

global Frame, TimeNow, YOLO_net


def runThread():
    threading.Timer(10, runThread).start()
    with lock:
        blob = cv2.dnn.blobFromImage(Frame, 0.00392, (416, 416), (0, 0, 0), True, crop=False)
    YOLO_net.setInput(blob)
    outs = YOLO_net.forward(output_layers)

    class_ids = []
    confidences = []
    
    for out in outs:
        for detection in out:
            scores = detection[5:]
            class_id = np.argmax(scores)
            confidence = scores[class_id]
            if confidence > 0.5:
                confidences.append(float(confidence))
                class_ids.append(class_id)
                
                
    set_class_ids = set()
    for i in class_ids:
        set_class_ids.add(i)
        
    labels = []
    for i in set_class_ids:
        label = str(classes[i])
        labels.append(label)
        
    print("labels", labels)
    Tag = ",".join(labels)

    if len(labels) != 0:
        Time1 = TimeNow.strftime("%Y-%m-%d %H")
        Time2 = TimeNow.strftime("%M:%S")    
            
        conn = pymysql.connect(host='192.168.1.139', user='minki', password='1q2w3e4r.', db='stray_db',charset='utf8')
        cursor = conn.cursor()
        sql = "INSERT INTO CCTV (CamID, Time1, Time2, Tag) VALUES (%s, %s, %s, %s)"
        cursor.execute(sql,(CamID, Time1, Time2, Tag))
        conn.commit()
        conn.close()


def loadYoloNetwork():

    YOLO_net = cv2.dnn.readNet("yolov3.weights","yolov3.cfg")

    classes = []
    with open("yolo.names", "r") as f:
        classes = [line.strip() for line in f.readlines()]
    layer_names = YOLO_net.getLayerNames()
    output_layers = [layer_names[i[0] - 1] for i in YOLO_net.getUnconnectedOutLayers()]
    lock = threading.Lock()
        

CamID = 'H1'
VideoSignal = cv2.VideoCapture(0)

loadYoloNetwork()

threading.Timer(10, runThread).start()

while True:
    TimeNow = datetime.now()
    ret, Frame = VideoSignal.read()