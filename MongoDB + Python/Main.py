import json

import GenerateActivationHistory
import pandas as pd
import GenerateSamples
import pymongo
"""
Hello Nir and Amit, before running the program please make sure to generate 
activationReasonCollection and HandleException in mongoDB.
Both of these collections are found in this project folder and are necessary 
because we are preforming GET operation from mongo. And don't forget to change the mongo client address

This project is relatively similar to our final proj by many ways so we'll explain most of it
although we are sure its not necessary.

Instead of manually creating samples and inserting them to mongo,
we decided to write a python module that will do it for us.
this module generates 8760 samples, which is equivalent for taking a sample from the sensors
each hour(24 readings per day) and is also considerate of the season, the hour, the month, and the day.
Meaning that during the winter there is less sun light, temps are lower, low light at night and so on.
I must say it's pretty good :) 

Each sample consists of the following:
DateTime = yyyy-mm-dd hh:mm:ss, represents date and time in one obj.

Light sensor data = float number, representing lumen measurement.
Everything above 400 is considered day light, anything below is night light(street light, moon light...)

Moist sensors data = float number, representing the amount of water vapor in the air(humidity).
0-100 (in percentages). different data from diffrent sensors could be the result
of sensors deployed at different locations

Atmosphere sensors data = float number, representing the atmospheric pressure(inMd).
high pressure is associated with clear skies and calm weather(x>1022.689),
normal pressure is associated with steady weather.(1022.689>x>1009.144), 
low pressure is associated with warm air and rainstorms(x>1009.144).
different data from different sensors could be the result
of sensors deployed at different locations although it is highly unlikely.

Temperature sensor data = int number, representing degrees in celcius.

isRaining data = boolean.data calculated with atmosphere data and tempreature.
"""

def main():
        samples_collection = GenerateSamples.generate()  # Generating the collection automatically. This collection
        # will "hold" 8760 samples.
        activation_history_collection = GenerateActivationHistory.generate(samples_collection)  # Generating the
        # collection automatically, this collection consists of each time the system declared an "exception" (
        # too hot, hot and dry, low atmospheric pressure and so on) and what transmissions were activated.
        post_collection_to_db(samples_collection, "samples", f'mongodb://127.0.0.1:27017/')  # Adding generated
        # collection to DB
        post_collection_to_db(activation_history_collection, "activation_history", f'mongodb://127.0.0.1:27017/')  #
        # Adding generated collection to DB
        convert_collection_to_html(samples_collection, "Samples")  # Generating an .html file in the folder of
        # this proj, the html file consists of a table that is a direct mirror to the collection that is sent as
        # parameter.



def post_collection_to_db(collection, collection_name, client_address):
        """
        Post a collection to mongoDB
        :param collection: Collection to be posted
        :param collection_name: The name of which the collection will be saved in the DB
        :param client_address: MongoDB client address
        """
        client = pymongo.MongoClient(client_address)
        db = client["MongoFinal"]
        col = db[collection_name]
        col.insert_many(collection)
        client.close()


def convert_collection_to_html(collection, webpage_name:str):
        """
        Creating an .html file consisting of a table of all the documents in the collections
        :param collection: Collection to be converted and represented in an html table
        :param webpage_name: The name to the html file link
        """
        df = pd.DataFrame([t for t in collection])
        txt = df.to_html()
        file = open(webpage_name + ".html", "w")
        file.write(txt)
        file.close()


def  convert_collection_to_csv(collection, csv_name:str):
        """
         Creating an .csv file consisting of a table of all the documents in the collections
        :param collection: Collection to be converted and represented in an csv table
        :param csv_name: The name to the csv file link
        """
        df = pd.DataFrame([t for t in collection])
        txt = df.to_csv()
        file = open(csv_name + ".csv", "w")
        file.write(txt)
        file.close()


if __name__ == '__main__':
        main()
