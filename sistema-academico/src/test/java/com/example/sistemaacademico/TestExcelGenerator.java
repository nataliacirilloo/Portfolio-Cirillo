package com.example.sistemaacademico;

import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.ss.usermodel.Sheet;
import org.apache.poi.ss.usermodel.Workbook;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;
import org.junit.jupiter.api.Test;

import java.io.FileOutputStream;
import java.io.IOException;

public class TestExcelGenerator {

    @Test
    public void generateExcel() throws IOException {
        try (Workbook workbook = new XSSFWorkbook()) {
            Sheet sheet = workbook.createSheet("Plan");

            Row header = sheet.createRow(0);
            header.createCell(0).setCellValue("Año");
            header.createCell(1).setCellValue("Cuatrimestre");
            header.createCell(2).setCellValue("Código");
            header.createCell(3).setCellValue("Asignatura");

            Object[][] data = {
                    { 1, 1, "01", "Matematica I" },
                    { 1, 1, "02", "Programacion I" },
                    { 1, 2, "03", "Sistemas de Datos" },
                    { 1, 2, "04", "Ingles I" },
                    { 2, 1, "05", "Matematica II" },
                    { 2, 1, "06", "Programacion II" }
            };

            int rowNum = 1;
            for (Object[] rowData : data) {
                Row row = sheet.createRow(rowNum++);
                row.createCell(0).setCellValue((Integer) rowData[0]);
                row.createCell(1).setCellValue((Integer) rowData[1]);
                row.createCell(2).setCellValue((String) rowData[2]);
                row.createCell(3).setCellValue((String) rowData[3]);
            }

            try (FileOutputStream fileOut = new FileOutputStream("plan_test.xlsx")) {
                workbook.write(fileOut);
            }
        }
        System.out.println("Excel generated: plan_test.xlsx");
    }
}
