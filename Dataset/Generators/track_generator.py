print('''
DELETE FROM "TRACK";
COMMIT;
''')

tracks = [
    #[email,  "DATE", CALORIES, PROTEINS, FAT, CARBONHYDRATES ]
    ['anne.mitchel@yahoo.com', '2023-12-24', 2600, 80, 79, 201],
    ['anne.mitchel@yahoo.com', '2023-12-25', 2300, 99, 77, 190],
    ['anne.mitchel@yahoo.com', '2023-12-26', 2700, 103, 59, 178],
    ['anne.mitchel@yahoo.com', '2023-12-27', 2050, 120, 70, 211],
    ['anne.mitchel@yahoo.com', '2023-12-28', 2050, 111, 64, 244],
    ['anne.mitchel@yahoo.com', '2023-12-29', 2100, 117, 61, 243],
    ['anne.mitchel@yahoo.com', '2023-12-30', 2150, 90, 69, 210],
    ['anne.mitchel@yahoo.com', '2023-12-31', 2800, 80, 66, 190],
    ['samuel.hardy@gmail.com', '2024-01-14', 2400, 110, 85, 175],
    ['samuel.hardy@gmail.com', '2024-01-15', 2421, 89, 84, 179],
    ['samuel.hardy@gmail.com', '2024-01-16', 2376, 99, 77, 175],
    ['samuel.hardy@gmail.com', '2024-01-17', 2015, 112, 68, 150],
    ['samuel.hardy@gmail.com', '2024-01-18', 2342, 91, 65, 180],
    ['samuel.hardy@gmail.com', '2024-01-19', 2102, 103, 71, 232],
    ['samuel.hardy@gmail.com', '2024-01-20', 2320, 108, 78, 250],
    ['samuel.hardy@gmail.com', '2024-01-21', 2103, 97, 87, 179],
    ['samuel.hardy@gmail.com', '2024-01-22', 2233, 98, 81, 248],
    ['samuel.hardy@gmail.com', '2024-01-23', 2367, 99, 61, 215],
    ['samuel.hardy@gmail.com', '2024-01-24', 2328, 94, 75, 222],
    ['samuel.hardy@gmail.com', '2024-01-25', 2160, 113, 89, 204],
    ['samuel.hardy@gmail.com', '2024-01-26', 2145, 112, 66, 180],
    ['samuel.hardy@gmail.com', '2024-01-27', 2245, 107, 67, 213],
    ['samuel.hardy@gmail.com', '2024-01-28', 2307, 105, 61, 205],
    ['samuel.hardy@gmail.com', '2024-01-29', 2199, 81, 85, 198],
    ['samuel.hardy@gmail.com', '2024-01-30', 2379, 101, 86, 173],
    ['samuel.hardy@gmail.com', '2024-01-31', 2149, 110, 85, 228]
]

trackInsert = '''
INSERT INTO TRACK (EMAIL, "DATE", CALORIES, PROTEIN, FAT, CARBONHYDRATES) 
VALUES ('{email}', TO_DATE('{date}', 'YYYY-MM-DD'), {calories}, {proteins}, {fat}, {carbonhydrates});'''

def generateTracks():
    print('''
--------------------------------------------
-- Generate the calorie-tracks for some users.
--------------------------------------------
    ''')
    for trackInfo in tracks:
        print(trackInsert.format(
            email = trackInfo[0],
            date = trackInfo[1],
            calories = trackInfo[2],
            proteins = trackInfo[3],
            fat = trackInfo[4],
            carbonhydrates = trackInfo[5]
        ))

if __name__ == "__main__":
    generateTracks()