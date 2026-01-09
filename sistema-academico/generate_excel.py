import openpyxl

wb = openpyxl.Workbook()
ws = wb.active
ws.title = "Plan"

# Header
ws.append(["Materia", "Anio", "Cuatrimestre", "Creditos"])

# Data
data = [
    ["Matematica I", 1, 1, 6],
    ["Programacion I", 1, 1, 8],
    ["Sistemas de Datos", 1, 2, 6],
    ["Ingles I", 1, 2, 4],
    ["Matematica II", 2, 1, 6],
    ["Programacion II", 2, 1, 8]
]

for row in data:
    ws.append(row)

wb.save("plan_test.xlsx")
print("Verified: plan_test.xlsx created")
