﻿using Newtonsoft.Json;
using System;

namespace PowerPointAddIn1
{
    [JsonObject(Title = "question")]
    public class Question
    {
        [JsonProperty(PropertyName = "lecture")]
        public Lecture Lecture { get; set; }
        [JsonProperty(PropertyName = "chapter")]
        public Chapter Chapter { get; set; }
        [JsonProperty(PropertyName = "survey")]
        public Survey Survey { get; set; }
        [JsonProperty(PropertyName = "push_slide_id")]
        public int? PushSlideId { get; set; }
        [JsonProperty(PropertyName = "push_slide_index")]
        public int? PushSlideIndex { get; set; }
        [JsonProperty(PropertyName = "evaluate_slide_id")]
        public int? EvaluateSlideId { get; set; }
        [JsonProperty(PropertyName = "evaluate_slide_indexd")]
        public int? EvaluateSlideIndex { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "question")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "is_text_response")]
        public int isTextResponse { get; set; }

        public Boolean IsPushed { get; set; }

        public Boolean IsEvaluated { get; set; }


        public Question(Lecture lecture, Chapter chapter, Survey survey, int? PushSlideId, int? PushSlideIndex, int? EvaluateSlideId, int? EvaluateSlideIndex,
            string ID, int isTextResponse, Boolean IsPushed, Boolean IsEvaluated)
        {
            this.Lecture = lecture;
            this.Chapter = chapter;
            this.Survey = survey;
            this.PushSlideId = PushSlideId;
            this.PushSlideIndex = PushSlideIndex;
            this.EvaluateSlideId = EvaluateSlideId;
            this.EvaluateSlideIndex = EvaluateSlideIndex;
            this.ID = ID;
            this.isTextResponse = isTextResponse;
            this.IsPushed = IsPushed;
            this.IsEvaluated = IsEvaluated;
        }

        public void setLectureChapterSurvey(Lecture lecture, Chapter chapter, Survey survey)
        {
            this.Lecture = lecture;
            this.Chapter = chapter;
            this.Survey = survey;
        }
    }
}
