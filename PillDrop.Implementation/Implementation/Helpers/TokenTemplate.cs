using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace PillDrop.Implementation.Implementation.Helpers
{
    public class TokenTemplate
    {
        private bool _scancomplete;
        private string _body;
        private readonly List<string> _tokens;

        public string Body
        {
            set
            {
                _body = value;
            }
            get
            {
                return _body;
            }
        }

        public List<string> Tokens()
        {
            ScanDocument();
            return _tokens;
        }

        public TokenTemplate(string tokenFilename)
        {
            _scancomplete = false;
            _body = string.Empty;
            _tokens = new List<string>();
            ReadBody(tokenFilename);
        }

        public void ReadBody(string tokenFilename)
        {
            var path = HttpContext.Current.Server.MapPath(tokenFilename);
            string result = string.Empty;
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(path ?? throw new InvalidOperationException());
                string line;
                do
                {
                    line = sr.ReadLine();
                    result += line;
                }
                while (line != null);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("File {0} could not be read. <br><br>" + ex.StackTrace, tokenFilename));
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                }
            }
            _body = result;
        }

        public void ScanDocument()
        {
            var re = new Regex("%.*?%", RegexOptions.IgnoreCase);
            var matchList = re.Matches(Body);
            foreach (Match d in matchList)
            {
                if (!_tokens.Contains(d.Value))
                {
                    _tokens.Add(d.Value);
                }
            }
            _scancomplete = true;
        }

        public void SetTokenValue(string token, string value)
        {
            if (_scancomplete == false)
            {
                ScanDocument();
            }
            string searchToken = "%" + token + "%";
            if (_body.IndexOf(searchToken, StringComparison.Ordinal) <= 0)
                throw new ETokenNotFound(token);
            _body = _body.Replace(searchToken, value);
        }
    }
}