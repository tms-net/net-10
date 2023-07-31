namespace HW28
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.MapGet("/resume", (HttpContext context) =>
            {
                context.Response.StatusCode = 200;
                context.Response.WriteAsync(@"
                            <!DOCTYPE html>
                            <html>
                                <head>
                                    <meta charset=""UTF-8"">
                                    <title>�� ������</title>
                                    <script>
                                                window.onload = function () {
                                                // Personal Block
                                                var personalBlock = document.createElement(""div"");
    
                                                var personalHeader = document.createElement(""h2"");
                                                var personalHeaderTextNode = document.createTextNode(""������ ������"");
                                                personalHeader.appendChild(personalHeaderTextNode);

                                                var name = document.createElement(""p"");
                                                var nameTextNode = document.createTextNode(""���: ������� �������"");
                                                name.appendChild(nameTextNode);

                                                var email = document.createElement(""p"");
                                                var emailTextNode = document.createTextNode(""�����: potapov@gmail.com"");
                                                email.appendChild(emailTextNode);
    
                                                personalBlock.appendChild(personalHeader);
                                                personalBlock.appendChild(name);
                                                personalBlock.appendChild(email);



                                                // Work block
                                                var workBlock = document.createElement(""div"");
  
                                                var workHeader = document.createElement(""h2"");
                                                var workHeaderTextNode = document.createTextNode(""���� ������"");
                                                workHeader.appendChild(workHeaderTextNode);

                                                var job = document.createElement(""p"");
                                                var jobTextNode = document.createTextNode(""���������: ��������� �������������"");
                                                job.appendChild(jobTextNode);

                                                var company = document.createElement(""p"");
                                                var companyTextNode = document.createTextNode(""����� ������: ��� \""CKC\"""");
                                                company.appendChild(companyTextNode);

                                                var responsibilities = document.createElement(""p"");
                                                var responsibilitiesTextNode = document.createTextNode(""�����������: ����������� ������������� ������ ������������������ ������� ����"");
                                                responsibilities.appendChild(responsibilitiesTextNode);

                                                workBlock.appendChild(workHeader);
                                                workBlock.appendChild(job);
                                                workBlock.appendChild(company);
                                                workBlock.appendChild(responsibilities);



                                                // Education block
                                                var educationBlock = document.createElement(""div"");

                                                var educationHeader = document.createElement(""h2"");
                                                var educationTextNode = document.createTextNode(""�����������"");
                                                educationHeader.appendChild(educationTextNode);

                                                var institution = document.createElement(""p"");
                                                var institutionTextNode = document.createTextNode(""������� ���������: ����������-���������� �����������"");
                                                institution.appendChild(institutionTextNode);

                                                var specialization = document.createElement(""p"");
                                                var specializationTextNode = document.createTextNode(""�������������: ������������������ ������� ��������� � ����������� ����������"");
                                                specialization.appendChild(specializationTextNode);

                                                educationBlock.appendChild(educationHeader);
                                                educationBlock.appendChild(institution);
                                                educationBlock.appendChild(specialization);







                                                //About me block
                                                var aboutMeBlock = document.createElement(""div"");
    
                                                var aboutMeHeader = document.createElement(""h2"");
                                                var aboutMeTextNode = document.createTextNode(""� ����"");
                                                aboutMeHeader.appendChild(aboutMeTextNode);


                                                var aboutMe = document.createElement(""p"");
                                                var aboutTextNode = document.createTextNode(""��������� ����� �� ������, ������� ����."");
                                                aboutMe.appendChild(aboutTextNode);

                                                aboutMeBlock.appendChild(aboutMeHeader);
                                                aboutMeBlock.appendChild(aboutMe);










                                                var rootElement = document.querySelector("".root"");
                                                rootElement.appendChild(personalBlock);
                                                rootElement.appendChild(workBlock);
                                                rootElement.appendChild(educationBlock);
                                                rootElement.appendChild(aboutMeBlock);

  
                                                rootElement.style.flexDirection = ""column""; 
                                                rootElement.style.textAlign = ""center""; 



                                                personalHeader.style.color = 'blue'; 
                                                name.style.fontWeight = 'bold'; 
                                                name.style.display = 'inline-block';
                                                email.style.textDecoration = 'underline'; 

                                                workHeader.style.color = 'green'; 
                                                job.style.fontStyle = 'italic'; 

                                                educationHeader.style.color = 'purple'; 

                                                aboutMeHeader.style.backgroundColor = 'yellow'; 
 

                                                name.setAttribute('class', 'my-class');
                                                name.style.backgroundColor = 'gray';
                                                aboutMeBlock.style.display = 'inline-block';
                                            }

                                    </script>
                                    <style>
                                        .root {
                                            margin: 0;
                                        }
                                    </style>
                                </head>
                                <body>
                                    <div class=""root"">
                                        <!-- HTML �������� ������ ����������� � ������� Javascript -->
                                    </div>
                                </body>
                            </html>
                ");
            });



            app.Run();
        }
    }
}