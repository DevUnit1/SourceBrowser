﻿namespace SourceBrowser.Site.Models
{
    using SourceBrowser.SolutionRetriever;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class GithubRepoStructure
    {
        public string Name { get; set; }

        public IList<string> Solutions { get; set; }

        public string ParentUserName { get; set; }

        public DateTime UploadTime { get; set; } // todo: populate.

        public int forksCount;
        public int starsCount;
        public string language;
        public string homepage;
        public bool isPrivate;
        public string description;

        public void UseLiveData()
        {
            GitHubInformationRetriever.GetRepoInformation(ParentUserName, Name, ref forksCount, ref starsCount, ref language, ref homepage, ref isPrivate, ref description);
        }

        public override string ToString()
        {
            return string.Format(
                "{0}'s repository {1} with {2} solution{3}",
                ParentUserName,
                Name,
                Solutions.Count,
                Solutions.Count == 1 ? "" : "s");
        }
    }
}