namespace PianoMelody.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Contracts;
    using Models;

    public class PianoMelodyData : IPianoMelodyData
    {
        private DbContext context;

        private Dictionary<Type, object> repositories;

        public PianoMelodyData()
            : this(new PianoMelodyContext())
        {
        }

        public PianoMelodyData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ArticleGroup> ArticleGroups
        {
            get
            {
                return this.GetRepository<ArticleGroup>();
            }
        }

        public IRepository<Article> Articles
        {
            get
            {
                return this.GetRepository<Article>();
            }
        }

        public IRepository<Information> Informations
        {
            get
            {
                return this.GetRepository<Information>();
            }
        }

        public IRepository<Manufacturer> Manufacturers
        {
            get
            {
                return this.GetRepository<Manufacturer>();
            }
        }

        public IRepository<Multimedia> Multimedia
        {
            get
            {
                return this.GetRepository<Multimedia>();
            }
        }

        public IRepository<News> News
        {
            get
            {
                return this.GetRepository<News>();
            }
        }

        public IRepository<Reference> References
        {
            get
            {
                return this.GetRepository<Reference>();
            }
        }

        public IRepository<Resources> Resources
        {
            get
            {
                return this.GetRepository<Resources>();
            }
        }

        public IRepository<Service> Services
        {
            get
            {
                return this.GetRepository<Service>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}