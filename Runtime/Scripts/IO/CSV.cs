using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

namespace SLIDDES.IO
{
    /// <summary>
    /// Handels interacting with csv files
    /// </summary>
    public static class CSV
    {
        // ! Important ! the file has to end on .csv ! it does not read xslx files
        // Row = horizontal
        // Collum = vertical
        
        /// <summary>
        /// Regex split pattern
        /// </summary>
        private static string splitPattern = @";(?=(?:[^""]*""[^""]*"")*[^""]*$)";
               
        /// <summary>
        /// Reads a csv string and returns a list of rows and columns
        /// </summary>
        /// <param name="csvContent">the csv content in string</param>
        /// <param name="startFromRow">Start reading from given row index</param>
        /// <returns>List<string[]></returns>
        public static List<string[]> ReadLines(string csvContent, int startFromRow)
        {
            var lines = csvContent.Split('\n');
            var rows = new List<string[]>();

            for(int i = startFromRow; i < lines.Length; i++)
            {
                var line = lines[i].Trim();

                if(string.IsNullOrEmpty(line))
                {
                    continue;
                }

                var cells = Regex.Split(line, splitPattern);

                for(int c = 0; c < cells.Length; c++)
                {
                    cells[c] = cells[c].Trim().Trim('"');
                }
                rows.Add(cells);
            }

            return rows;
        }

        /// <summary>
        /// Stream read lines from a cvs file
        /// </summary>
        /// <param name="filePath">The file path of the csv file</param>
        /// <param name="rowStartIndex">The start index at which to read the row</param>
        /// <param name="maxLinesPerFrame">The amount of lines to read per frame</param>
        /// <param name="totalLinesFound">Action callback for the amount of lines found</param>
        /// <param name="currentLineIndex">Action callback to tell at which line the stream reader is</param>
        /// <param name="readAllRows">Action callback when all rows are read (with the contents as callback value)</param>
        /// <returns></returns>
        public static IEnumerator ReadLinesStream(string filePath, int rowStartIndex, int maxLinesPerFrame, Action<int> totalLinesFound, Action<int> currentLineIndex, Action<List<string[]>> readAllRows)
        {
            int lineNr = 0;
            List<string[]> rows = new List<string[]>();
            int totalLines = 0;

            using(StreamReader streamReader = File.OpenText(filePath))
            {
                //Quick pass to count the newlines:
                while(streamReader.ReadLine() != null)
                {
                    totalLines++;
                }
                totalLinesFound.Invoke(totalLines);

                //Reset streamreader to read the actual lines
                streamReader.DiscardBufferedData();
                streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                while(streamReader.Peek() >= 0)
                {
                    var readLine = streamReader.ReadLine();
                    var line = readLine.Trim();
                    lineNr++;

                    if(lineNr % maxLinesPerFrame == 0)
                    {
                        currentLineIndex.Invoke(lineNr);
                        yield return new WaitForEndOfFrame();
                    }
                    if(lineNr < rowStartIndex) continue;

                    if(string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    var cells = Regex.Split(line, splitPattern);
                    for(int c = 0; c < cells.Length; c++)
                    {
                        cells[c] = cells[c].Trim().Trim('"');
                    }

                    rows.Add(cells);
                }
            }

            readAllRows.Invoke(rows);
        }
    }
}