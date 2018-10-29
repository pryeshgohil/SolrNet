﻿using System;
using System.Collections.Generic;
using System.IO;
using Moroco;
using System.Threading.Tasks;
using System.Threading;

namespace SolrNet.Tests.Mocks {
    public class MSolrConnection : ISolrConnection {
        public MFunc<string, string, string> post;
        public MFunc<string, string, Stream, IEnumerable<KeyValuePair<string,string>>, string> postStream;
        public MFunc<string, IEnumerable<KeyValuePair<string, string>>, string> get;

        public MFunc<string, string, Task<string>> postAsync;
        public MFunc<string, string, Stream, IEnumerable<KeyValuePair<string, string>>, Task<string>> postStreamAsync;
        public MFunc<string, IEnumerable<KeyValuePair<string, string>>,Task< string>> getAsync;

        public string Post(string relativeUrl, string s) {
            if (post == null)
                throw new NotImplementedException(string.Format("Post called with\n{0}\n{1}", relativeUrl, s));
            return post.Invoke(relativeUrl, s);
        }

        public string PostStream(string relativeUrl, string contentType, Stream content, IEnumerable<KeyValuePair<string, string>> getParameters) {
            if (postStream == null)
                throw new NotImplementedException();
            return postStream.Invoke(relativeUrl, contentType, content, getParameters);
        }

        public string Get(string relativeUrl, IEnumerable<KeyValuePair<string, string>> parameters) {
            return get.Invoke(relativeUrl, parameters);
        }

        public Task<string> PostAsync(string relativeUrl, string s)
        {
            if (post == null)
                throw new NotImplementedException(string.Format("Post called with\n{0}\n{1}", relativeUrl, s));
            return postAsync.Invoke(relativeUrl, s);
        }

        public Task<string> PostStreamAsync(string relativeUrl, string contentType, Stream content, IEnumerable<KeyValuePair<string, string>> getParameters)
        {
            if (postStream == null)
                throw new NotImplementedException();
            return postStreamAsync.Invoke(relativeUrl, contentType, content, getParameters);
        }

        public Task<string> GetAsync(string relativeUrl, IEnumerable<KeyValuePair<string, string>> parameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            return getAsync.Invoke(relativeUrl, parameters);
        }
    }
}
