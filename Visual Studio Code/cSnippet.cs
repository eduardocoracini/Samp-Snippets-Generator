using System;
using System.IO;
using System.Text;

namespace nSnippet
{
    public class cSnippet
    {
        public void GenerateSnippets(string path, string[] directives, string saveTo, bool generateDictionay)
        {
            // snippets
            StringBuilder snippets = new StringBuilder();
            StringBuilder dictionary = new StringBuilder();
            StringBuilder invalidDirectives = new StringBuilder();

            string snippetsFile = "snippets.code-snippets";
            string dictionaryFile = "snippets_dictionary.txt";
            string errorFile = "snippets_error.txt";

            snippets.Append("{" + Environment.NewLine);

            foreach (string file in Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly))
            {
                FileInfo fileInfo = new FileInfo(file);
                string[] lines = File.ReadAllLines(fileInfo.FullName);

                foreach (string line in lines)
                {
                    string diretiveName = "";
                    string functionParams = "";

                    foreach (string directive in directives)
                    {
                        if (line.Trim().IndexOf(directive, StringComparison.CurrentCulture) == 0)
                        {
                            int idx1 = line.IndexOf(directive, StringComparison.CurrentCulture) + directive.Length;
                            int idx2 = line.IndexOf("(", StringComparison.CurrentCulture) + 1;
                            int idx3 = line.IndexOf(")", idx2, StringComparison.CurrentCulture);

                            if (idx2 > 0 && idx3 > 1)
                            {
                                diretiveName = line.Substring(idx1, idx2 - idx1 - 1).Trim();
                                string[] fParams = line.Substring(idx2, idx3 - idx2).Split(',');

                                int idx4 = diretiveName.IndexOf(':');
                                if (idx4 > -1)
                                    diretiveName = diretiveName.Substring(idx4 + 1, diretiveName.Length - idx4 - 1).Trim();

                                functionParams = "";
                                for (int index = 0; index < fParams.Length; ++index)
                                {
                                    if (fParams[index].Contains("{Float"))
                                    {
                                        functionParams = functionParams + "${" + (index + 1) + ":" + fParams[index].Replace("\"", "\\\"").Trim() + "}" + (index < fParams.Length - 2 ? ", " : null);
                                        ++index;
                                    }
                                    else
                                        functionParams = functionParams + "${" + (index + 1) + ":" + fParams[index].Replace("\"", "\\\"").Trim() + "}" + (index < fParams.Length - 1 ? ", " : null);
                                }
                            }
                            else if (idx2 > 0 && idx3 == -1)
                            {
                                invalidDirectives.Append("[" + fileInfo.Name + "] Invalid directive (break line?): " + line);
                            }
                            else if (idx2 == -1 && idx3 > 0)
                            {
                                invalidDirectives.Append("[" + fileInfo.Name + "] Invalid directive (break line?): " + line);
                            }
                        }
                    }

                    if (diretiveName != string.Empty)
                    {
                        diretiveName = diretiveName.Trim();

                        if (functionParams != string.Empty)
                            snippets.Append("   \"" + diretiveName + "\": { \"scope\": \"pawn\", \"prefix\": \"" + diretiveName + "\", \"body\": \"" + diretiveName + "(" + functionParams + ");$0\" }," + Environment.NewLine);
                        else
                            snippets.Append("   \"" + diretiveName + "\": { \"scope\": \"pawn\", \"prefix\": \"" + diretiveName + "\", \"body\": \"" + diretiveName + "\" }," + Environment.NewLine);

                        dictionary.Append(diretiveName + Environment.NewLine);
                    }
                }
            }

            snippets.Append("}");

            File.WriteAllText(saveTo + "\\" + snippetsFile + ".tmp", snippets.ToString());

            if (generateDictionay)
                File.WriteAllText(saveTo + "\\" + dictionaryFile + ".tmp", dictionary.ToString());

            snippets.Clear();
            dictionary.Clear();

            string[] lines2 = File.ReadAllLines(path + "\\" + snippetsFile +".tmp");
            for (int i = 0; i < lines2.Length; ++i)
            {
                bool equals = false;
                for (int ii = 0; ii < lines2.Length && i != ii; ++ii)
                {
                    if (!lines2[i].Contains("\"trigger\":") && !lines2[ii].Contains("\"trigger\":"))
                        continue;

                    if (lines2[i].Trim().Equals(lines2[ii].Trim(), StringComparison.CurrentCulture))
                    {
                        equals = true;
                        break;
                    }
                }

                if (!equals)
                    snippets.Append(lines2[i] + Environment.NewLine);
            }

            if (generateDictionay)
            {
                string[] lines3 = File.ReadAllLines(path + "\\" + dictionaryFile + ".tmp");
                for (int i = 0; i < lines3.Length; ++i)
                {
                    bool equals = false;
                    for (int ii = 0; ii < lines3.Length && i != ii; ++ii)
                    {
                        if (lines3[i].Equals(lines3[ii], StringComparison.CurrentCulture))
                        {
                            equals = true;
                            break;
                        }
                    }

                    if (!equals)
                        dictionary.Append(lines3[i] + Environment.NewLine);
                }
            }

            File.Delete(saveTo + "\\" + snippetsFile + ".tmp");
            File.WriteAllText(saveTo + "\\" + snippetsFile, snippets.ToString());

            if (generateDictionay)
            {
                File.Delete(saveTo + "\\" + dictionaryFile + ".tmp");
                File.WriteAllText(saveTo + "\\" + dictionaryFile, dictionary.ToString());
            }

            if (invalidDirectives.ToString() != string.Empty)
            {
                File.WriteAllText(saveTo + "\\" + errorFile, invalidDirectives.ToString());
            }
        }
    }
}
