using System;
using System.Collections.Generic;

namespace PullTracker.Models
{
    public class RequestValues
    {
        private string id;

        private string displayId;

        private string slug;

        private decimal version;

        private string title;

        private string description;

        private string state;

        private bool isOpen;

        private bool isClosed;

        private string createdDate;

        private string updatedDate;

        private FromRef fromRef;

        private ToRef toRef;

        private Author author;

        private Reviewers[] reviewers;

        //private Participants participants;

        //private Attributes attributes;

        private Link link;

        private Links links;

        private bool isDefault;

        private Dictionary<string,Object> metadata;

        private Details details;

        private bool enabled;

        private bool configured;

        public string Id { get { return this.id; } set { this.id = value; } }

        public string DisplayId { get { return this.displayId; } set { this.displayId = value; } }

        public string Slug { get { return this.slug; } set { this.slug = value; } }

        public decimal Version { get { return this.version; } set { this.version = value; } }

        public string Title { get { return this.title; } set { this.title = value; } }

        public string Description { get { return this.description; } set { this.description = value; }}

        public string State { get { return this.state; } set { this.state = value; } }

        public bool IsOpen { get { return this.isOpen; } set { this.isOpen = value; } }

        public bool IsClosed { get { return this.isClosed; } set { this.isClosed = value; } }

        public string CreatedDate { get { return this.createdDate; } set { this.createdDate = value; } }

        public string UpdatedDate { get { return this.updatedDate; } set { this.updatedDate = value; } }

        public FromRef FromRef { get { return this.fromRef; } set { this.fromRef = value; } }

        public ToRef ToRef { get { return this.toRef; } set { this.toRef = value; } }

        public Author Author { get { return this.author; } set { this.author = value; } }

        public Reviewers[] Reviewers { get { return this.reviewers; } set { this.reviewers = value; } }

        //public Participants Participants { get; set; }

       // public Attributes Attributes { get; set; }

        public Link Link { get { return this.link; } set { this.link = value; } }

        public Links Links { get { return this.links; } set { this.links = value; } }

        public bool IsDefault { get { return this.isDefault; } set { this.isDefault = value; } }

        public Dictionary<string, Object> MetaData { get { return this.metadata; } set { this.metadata = value; } }

        public Details Details { get { return this.details; } set { this.details = value; } }

        public bool Enabled { get { return this.enabled; } set { this.enabled = value; } }

        public bool Configured { get { return this.configured; } set { this.configured = value; } }

    }
}