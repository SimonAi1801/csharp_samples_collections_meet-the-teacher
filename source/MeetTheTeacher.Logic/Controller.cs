﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MeetTheTeacher.Logic
{
    /// <summary>
    /// Verwaltung der Lehrer (mit und ohne Detailinfos)
    /// </summary>
    public class Controller
    {
        private readonly List<Teacher> _teachers;
        private readonly Dictionary<string, int> _details;
        private string _inputPathTeacher = @"Teachers.csv";
        private string _inputPathIgnored = @"IgnoredTeachers.csv";
        private string _inputPathDetails = @"Details.csv";

        /// <summary>
        /// Liste für Sprechstunden und Dictionary für Detailseiten anlegen
        /// </summary>
        public Controller(string[] teacherLines, string[] detailsLines)
        {
            _teachers = new List<Teacher>();
            _details = new Dictionary<string, int>();

            InitDetails(detailsLines);
            InitTeachers(teacherLines);
        }

        public int Count => _teachers.Count;

        public int CountTeachersWithoutDetails => Count - CountTeachersWithDetails;

        /// <summary>
        /// Anzahl der Lehrer mit Detailinfos in der Liste
        /// </summary>
        public int CountTeachersWithDetails => _details.Count;

        /// <summary>
        /// Aus dem Text der Sprechstundendatei werden alle Lehrersprechstunden 
        /// eingelesen. Dabei wird für Lehrer, die eine Detailseite haben
        /// ein TeacherWithDetails-Objekt und für andere Lehrer ein Teacher-Objekt angelegt.
        /// </summary>
        /// <returns>Anzahl der eingelesenen Lehrer</returns>
        private void InitTeachers(string[] lines)
        {
            if (lines == null)
            {
                lines = File.ReadAllLines(_inputPathTeacher, Encoding.UTF8);
            }
            foreach (string line in lines)
            {
                string[] parts = line.Split(";");
                if (IsTeacherWithDetail(parts[0]))
                {
                    int value;
                    _details.TryGetValue(parts[0], out value);
                    Teacher newTeacher = new TeacherWithDetail(parts[0], parts[1],
                        parts[2], parts[3], parts[4], parts[5], value);
                    _teachers.Add(newTeacher);
                }
                else
                {
                    Teacher newTeacher = new Teacher(parts[0], parts[1], parts[2],
                        parts[3], parts[4], parts[5]);
                    _teachers.Add(newTeacher);
                }
            }
        }


        /// <summary>
        /// Lehrer, deren Name in der Datei IgnoredTeachers steht werden aus der Liste 
        /// entfernt
        /// </summary>
        public void DeleteIgnoredTeachers(string[] names)
        {
            if (names == null)
            {
                names = File.ReadAllLines(_inputPathIgnored, Encoding.UTF8);
            }

            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i];
                for (int j = 0; j < Count; j++)
                {
                    if (_teachers[j].Name.ToLower().Equals(name.ToLower()))
                    {
                        _teachers.RemoveAt(j);
                    }
                }
            }
        }

        /// <summary>
        /// Sucht Lehrer in Lehrerliste nach dem Namen
        /// </summary>
        /// <param name="teacherName"></param>
        /// <returns>Index oder -1, falls nicht gefunden</returns>
        private int FindIndexForTeacher(string teacherName)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Ids der Detailseiten für Lehrer die eine
        /// derartige Seite haben einlesen.
        /// </summary>
        private void InitDetails(string[] lines)
        {
            if (lines == null)
            {
                lines = File.ReadAllLines(_inputPathDetails, Encoding.UTF8);
            }
            foreach (string line in lines)
            {
                string[] parts = line.Split(";");
                string name = parts[0];
                int id = Convert.ToInt32(parts[1]);
                _details.Add(name, id);
            }
        }

        /// <summary>
        /// HTML-Tabelle der ganzen Lehrer aufbereiten.
        /// </summary>
        /// <returns>Text für die Html-Tabelle</returns>
        public string GetHtmlTable()
        {
            throw new NotImplementedException();
        }

        #region private
        private bool IsTeacherWithDetail(string name)
        {
            return _details.ContainsKey(name.ToLower());
        }
        #endregion
    }
}
