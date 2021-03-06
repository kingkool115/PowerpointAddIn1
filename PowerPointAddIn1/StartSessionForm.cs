﻿using Newtonsoft.Json;
using PowerPointAddIn1.utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PowerPointAddIn1
{
    public partial class StartSessionForm : Form
    {
        // basically to access pptNavigator.
        MyRibbon myRibbon;
        
        // if start session from first slide or not.
        bool fromBeginning;

        // if someone starts the presentation who didn't log in before, than false
        bool isUserLoggedIn;

        // list of lectures
        List<Lecture> lectureList;

        /*
         * Constructor.
         */
        public StartSessionForm(MyRibbon myRibbon, bool fromBeginning, bool isUserLoggedIn, IRestResponse response)
        {
            InitializeComponent();
            this.myRibbon = myRibbon;
            this.fromBeginning = fromBeginning;
            this.isUserLoggedIn = isUserLoggedIn;
            fillComboBox(response);
            start_session_lectures_combo.DisplayMember = "Text";
            start_session_lectures_combo.ValueMember = "Value";
        }

        /*
         * Fill lecture and chapter comboboxes with values.
         */
        public void fillComboBox(IRestResponse response)
        {
            // fill lecture combo with all available lectures
            var content = response.Content;
            lectureList = JsonConvert.DeserializeObject<List<Lecture>>(content);
            foreach (var lectureItem in lectureList)
            {
                start_session_lectures_combo.Items.Add(
                    new { Text = lectureItem.Name, Value = lectureItem.ID });
            }

            // fill lectureList
            foreach (var lect in lectureList)
            {
                var chapterList = myRibbon.myRestHelper.GetChaptersOfLectureAsGuest(lect.ID);
                lect.setChapters(chapterList);
            }

            if (myRibbon.LectureForThisPresentation != null)
            {
                start_session_lectures_combo.SelectedItem = 
                    new { Text = myRibbon.LectureForThisPresentation.Name, Value = myRibbon.LectureForThisPresentation.ID };
            }
        }
        
        /*
         * Start presentation and record it.
         */
        private void start_session_start_record_button_Click(object sender, EventArgs e)
        {
            if (start_session_lectures_combo.SelectedItem == null) {
                start_session_error.Visible = true;
                return;
            }

            String selectedLectureId = (String)(start_session_lectures_combo.SelectedItem as dynamic).Value;
            myRibbon.startNewSession(selectedLectureId, fromBeginning, (int)numeric_seconds_spent.Value);
            Close();
        }

        /*
         * Get a lecture from myLectures by id.
         */
        public Lecture getLectureById(String lectureId)
        {
            foreach (var lecture in lectureList)
            {
                if (lecture.ID.Equals(lectureId))
                {
                    return lecture;
                }
            }
            return null;
        }

        private void StartSessionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
