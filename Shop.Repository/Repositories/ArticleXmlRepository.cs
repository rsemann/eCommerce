﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using Shop.Dto;
using Shop.Repository.Interfaces;

namespace Shop.Repository.Repositories
{
    public class ArticleXmlRepository : IRepository<ArticleDTO>
    {
        public string _path;
        private static List<ArticleDTO> _articles = new List<ArticleDTO>();

        //public ArticleXmlRepository(string path)
        //{
        //    _path = path;
        //    if (_articles.Count > 0)
        //        LoadArticlesFromXMl();
        //}

        public IEnumerable<ArticleDTO> GetAll()
        {
            return _articles;
        }

        public ArticleDTO GetById(int articleId)
        {
            return _articles.FirstOrDefault(a => a.ArticleId == articleId);
        }

        public void Add(ArticleDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ArticleDTO item)
        {
            throw new NotImplementedException();
        }

        private void LoadArticlesFromXMl()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(string.Format(@"{0}\articles.xml", _path));

            if (doc.DocumentElement != null)
            {
                XmlNodeList nodes = doc.DocumentElement.SelectNodes("/ArrayOfArticle/Article");
                foreach (XmlNode node in nodes)
                {

                    _articles.Add(new ArticleDTO
                    {
                        ArticleId = Convert.ToInt32(node.SelectSingleNode("Id").InnerText),
                        ArticleName = node.SelectSingleNode("Name").InnerText,
                        ArticleDescription = node.SelectSingleNode("Description").InnerText,
                        ArticleValue = Convert.ToSingle(node.SelectSingleNode("Value").InnerText, CultureInfo.InvariantCulture)
                    });
                }
            }
        }
    }
}
