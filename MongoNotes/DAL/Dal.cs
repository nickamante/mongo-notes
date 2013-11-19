using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoNotes.Models;

namespace MongoNotes.DAL
{
    public class Dal : IDisposable
    {
        private MongoServer mongoServer;
        private bool disposed = false;

        private string connectionString = System.Environment.GetEnvironmentVariable("CUSTOMCONNSTR_MONGOLAB_URI");

        private string dbName = "MongoLab";
        private string collectionName = "Notes";
        public Dal()
        {

        }

        public List<Note> GetAllNotes()
        {
            try
            {
                MongoCollection<Note> collection = getNotesCollection();
                return collection.FindAll().ToList<Note>();
            }
            catch (MongoConnectionException)
            {
                return new List<Note>();
            }
        }

        // Create a Note and insert it into the collection in MongoDB.
        public void CreateNote(Note note)
        {
            MongoCollection<Note> collection = getNotesCollectionForEdit();
            try
            {
                collection.Insert(note, SafeMode.True);
            }
            catch (MongoCommandException ex)
            {
                string message = ex.Message;
            }
        }

        private MongoCollection<Note> getNotesCollection()
        {
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase(dbName);
            MongoCollection<Note> noteCollection = database.GetCollection<Note>(collectionName);
            return noteCollection;
        }

        private MongoCollection<Note> getNotesCollectionForEdit()
        {
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase(dbName);
            MongoCollection<Note> noteCollection = database.GetCollection<Note>(collectionName);
            return noteCollection;
        }

        # region IDisposable
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (mongoServer != null)
                    {
                        mongoServer.Disconnect();
                    }
                }
            }

            this.disposed = true;
        }
        #endregion

    }
}