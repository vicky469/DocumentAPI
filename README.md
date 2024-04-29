# DocumentAPI
Document API is a simple tool designed to parse SEC (Securities and Exchange Commission) EDGAR data. It is built using the latest .NET 8 Minimal API, providing a lean and efficient framework for building HTTP APIs.  
## Features
- Parses SEC documents and extracts relevant data. (build in progress)
- Use LLM to create a chatbot to answer questions from sec documents. (coming soon)
## How to Run the Project
1. Ensure you have .NET 8 SDK installed on your machine. You can download it from the official .NET website.  
2. Clone the repository which will open the solution:  <pre>git clone https://github.com/your-repo/DocumentAPI.git </pre>
3. Open the user secret file and paste this in the file.
    I am using Mac, the user secret file in Rider IDE is by right-click the project -> tools -> .NET user secrets. 
    <pre>{"SecUserAgent": "Personal-Project/1.0 (+{{your email}@gmail.com)"}</pre>

4. Run the project.
   
   <img src="./swagger.png" width="50%" height="50%">

## How It was built
### Analysis
1. Understand the data
   - Schema: https://www.sec.gov/files/form10-k.pdf / https://sec-api.io/docs/sec-filings-item-extraction-api
   - Scraping rule: https://www.sec.gov/os/webmaster-faq#developers
   - Search: https://www.sec.gov/edgar/search/#/q=Microsoft&category=custom&forms=10-K
2. Understand the requirement
   - Start from 10K and 10Q forms.
   - Extract the specific sections from the forms.
   - Do a load testing, say 200 documents.
### Code
1. Create a new project using the .NET 8 Minimal API template.
2. Used HTTP client factory to make the HTTP request. [1]
3. Libraries
   - HtmlAgilityPack library to parse the HTML documents
   - Carter library for routing and handling requests, so I don't need to write my own filters from scratch and can have more time to focus on the business.
   - Polly library that provides resilience strategies in fluent-to-express policies such as Retry, WaitAndRetry, and CircuitBreaker, etc.
   - Serilog library for logging. (future)


### References
[1] https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
