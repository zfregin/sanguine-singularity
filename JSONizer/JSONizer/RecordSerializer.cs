using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace JSONizer
{
    class RecordSerializer
    {
        public string Converter(string inputFile)
        {
            // current line in file
            string line;
            string jsonResult;
            // storage for previous record
            string[] prevLine = {};
            // list to collect all items for an order
            List<String> itemList = new List<String>();
            // used to trim quotes from number values
            char[] trimChars = { '\"' };
            // stringbuilder object used to create full JSON string, record by record
            StringBuilder sb = new StringBuilder();
            // initialize streamreader to open csv file for reading
            StreamReader file = new StreamReader(inputFile);
            // iterates through the csv file line by line until null line encountered
            while ((line = file.ReadLine()) != null)
            {
                // create an array of all the strings in the line that are separated by comma
                string[] fields = line.Split(',');

                // check the record type of the line and format based on matching case
                switch (fields[0])
                {
                    case "\"F\"":
                        fileInfoFormat(sb, fields);
                        break;

                    case "\"O\"":
                        orderFormat(sb, fields, prevLine);
                        break;

                    case "\"B\"":
                        buyerFormat(sb, fields);
                        break;

                    case "\"L\"":
                        itemFormat(fields, itemList);
                        break;

                    case "\"T\"":
                        timingFormat(sb, fields, itemList);
                        break;

                    case "\"E\"":
                        enderFormat(sb, fields);
                        break;

                }
                // store line for later comparison
                prevLine = fields;
                        
            }
            // close the csv file reading stream
            file.Close();
            // cast stringbuilder object to string for return
            jsonResult = sb.ToString();
            return jsonResult;
        }

        // Adds file info fields to JSON
        private void fileInfoFormat(StringBuilder sb, string[] fields)
        {
            sb.Append("{");
            sb.AppendLine();
            for (int i = 1; i < fields.Length; i++)
            {
                sb.Append("\t");
                // appends the key/value pair for each field in the record
                switch (i)
                {
                    case 1:
                        sb.Append("\"date\":" + fields[i] + ",");
                        sb.AppendLine();
                        break;
                    case 2:
                        sb.Append("\"type\":" + fields[i] + ",");
                        sb.AppendLine();
                        break;
                }
            }
            sb.Append("\t\"orders\":[");
        }

        // adds order info fields to JSON
        private void orderFormat(StringBuilder sb, string[] fields, string[] prevLine)
        {
            // check if previous line was a timing record, indicating this is not the first order
            if (prevLine[0] == "\"T\"")
                sb.Append(",");
            sb.AppendLine();
            sb.Append("\t\t{");
            sb.AppendLine();
            for (int i = 1; i < fields.Length; i++)
            {
                sb.Append("\t\t\t");
                // appends the key/value pair for each field in the record
                switch (i)
                {
                    case 1:
                        sb.Append("\"date\":" + fields[i] + ",");
                        sb.AppendLine();
                        break;
                    case 2:
                        sb.Append("\"code\":" + fields[i] + ",");
                        sb.AppendLine();
                        break;
                    case 3:
                        sb.Append("\"number\":" + fields[i] + ",");
                        sb.AppendLine();
                        break;
                }
            }
        }

        // add buyer info fields to JSON
        private void buyerFormat(StringBuilder sb, string[] fields)
        {
            sb.Append("\t\t\t\"buyer\":{");
            sb.AppendLine();
            for (int i = 1; i < fields.Length; i++)
            {
                sb.Append("\t\t\t\t");
                // appends the key/value pair for each field in the record
                switch (i)
                {
                    case 1:
                        sb.Append("\"name\":" + fields[i] + ",");
                        sb.AppendLine();
                        break;
                    case 2:
                        sb.Append("\"street\":" + fields[i] + ",");
                        sb.AppendLine();
                        break;
                    case 3:
                        sb.Append("\"zip\":" + fields[i] + "");
                        sb.AppendLine();
                        break;
                }
            }
            sb.Append("\t\t\t},");
            sb.AppendLine();
            sb.Append("\t\t\t\"items\":[");
            sb.AppendLine();
        }

        // formats item objects and adds to list to add to JSON
        private void itemFormat(string[] fields, List<String> list)
        {
            // separate string builder to create object literal
            StringBuilder itemObject = new StringBuilder();
            itemObject.Append("\t\t\t\t{");
            itemObject.AppendLine();
            for (int i = 1; i < fields.Length; i++)
            {
                itemObject.Append("\t\t\t\t\t");
                // appends the key/value pair for each field in the record
                switch (i)
                {
                    case 1:
                        itemObject.Append("\"sku\":" + fields[i] + ",");
                        itemObject.AppendLine();
                        break;
                    case 2:
                        itemObject.Append("\"qty\":" + fields[i].Trim('\"'));
                        itemObject.AppendLine();
                        break;
                }
            }
            itemObject.Append("\t\t\t\t}");
            string item = itemObject.ToString();
            list.Add(item);
        }

        // Adds item objects and timing info to JSON
        private void timingFormat(StringBuilder sb, string[] fields, List<string> itemList)
        {
            // take array of item objects and join them into one string, separated by comma and new line
            string formattedItems = String.Join(",\n", itemList);
            // add item objects to JSON
            sb.Append(formattedItems);
            sb.AppendLine();
            // clear itemList for use in the next order
            itemList.Clear();
            sb.Append("\t\t\t],");
            sb.AppendLine();
            sb.Append("\t\t\t\"timings\":{");
            sb.AppendLine();
            for (int i = 1; i < fields.Length; i++)
            {
                sb.Append("\t\t\t\t");
                // appends the key/value pair for each field in the record and trims quotes from value
                switch (i)
                {
                    case 1:
                        sb.Append("\"start\":" + fields[i].Trim('\"') + ",");
                        sb.AppendLine();
                        break;
                    case 2:
                        sb.Append("\"stop\":" + fields[i].Trim('\"') + ",");
                        sb.AppendLine();
                        break;
                    case 3:
                        sb.Append("\"gap\":" + fields[i].Trim('\"') + ",");
                        sb.AppendLine();
                        break;
                    case 4:
                        sb.Append("\"offset\":" + fields[i].Trim('\"') + ",");
                        sb.AppendLine();
                        break;
                    case 5:
                        sb.Append("\"pause\":" + fields[i].Trim('\"'));
                        sb.AppendLine();
                        break;
                }
            }
            sb.Append("\t\t\t}");
            sb.AppendLine();
            sb.Append("\t\t}");
        }

        // add ender info to JSON
        private void enderFormat(StringBuilder sb, string[] fields)
        {
            sb.AppendLine();
            sb.Append("\t],");
            sb.AppendLine();
            sb.Append("\t\"ender\":{");
            sb.AppendLine();
            for (int i = 1; i < fields.Length; i++)
            {
                sb.Append("\t\t");
                // appends the key/value pair for each field in the record and trims quotes from value
                switch (i)
                {
                    case 1:
                        sb.Append("\"process\":" + fields[i].Trim('\"') + ",");
                        sb.AppendLine();
                        break;
                    case 2:
                        sb.Append("\"paid\":" + fields[i].Trim('\"') + ",");
                        sb.AppendLine();
                        break;
                    case 3:
                        sb.Append("\"created\":" + fields[i].Trim('\"'));
                        sb.AppendLine();
                        break;
                }
            }
            sb.Append("\t}");
            sb.AppendLine();
            sb.Append("}");
        }
    }
}
