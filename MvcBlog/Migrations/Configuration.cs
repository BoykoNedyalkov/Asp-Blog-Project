namespace MVCBlog.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MvcBlog.Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                // If the database is empty, populate sample data in it

                CreateUser(context, "admin@gmail.com", "123", "System Administrator");
                CreateUser(context, "pesho@gmail.com", "123", "Peter Ivanov");
                CreateUser(context, "merry@gmail.com", "123", "Maria Petrova");
                CreateUser(context, "geshu@gmail.com", "123", "George Petrov");

                CreateRole(context, "Administrators");
                AddUserToRole(context, "admin@gmail.com", "Administrators");

                CreatePost(context,
                    title: "Hyundai says it's discussing partnerships with Google",
                    body: @"SEOUL -- Hyundai Motor is in discussions with Google about further partnerships
                        as the automaker seeks external expertise to remain competitive. The two companies have some
                        common areas that may require cooperation, Hyundai Motor President Jeong Jin Haeng said after
                        a meeting between the trade ministry and local automakers. Hyundai has been among the most 
                        active automakers adopting Apple's CarPlay and Google parent Alphabet's Android Auto, 
                        which integrate iPhone and Android handsets with car dashboards. Jeong didn't give further
                        details or confirm if the automaker is considering developing autonomous cars with Google.",
                    date: new DateTime(2016, 03, 27, 17, 53, 48),
                    authorUsername: "merry@gmail.com"
                );

                CreatePost(context,
                    title: "Ford to make autonomous cars for ride-hailing, ride-sharing by 2021",
                    body: @"Ford Motor Co. today said it plans to introduce an autonomous vehicle by 2021 for
                            use in a ride-hailing or ride-sharing service. Ford said the vehicle would be “specifically
                            designed for commercial mobility services” and built in high volumes. “Ford is going to be 
                            mass-producing vehicles with full autonomy in five years,” CEO Mark Fields said at an event
                            in Silicon Valley that was broadcast online. “There’s going to be no steering wheel, there’s
                            not going to be a gas pedal, there’s not going to be a brake pedal and of course a driver is
                            not going to be required.",
                    date: new DateTime(2016, 05, 11, 08, 22, 03),
                    authorUsername: "merry@gmail.com"
                );

                CreatePost(context,
                    title: "Cadillac readies concept for Pebble Beach showing",
                    body: @"Cadillac plans to introduce a concept vehicle at this year's Pebble Beach Concours d'Elegance.
                            Cadillac isn't saying if the concept is an SUV, crossover or new sporty car.",
                    date: new DateTime(2016, 03, 27, 17, 53, 48),
                    authorUsername: "merry@gmail.com"
                );

                CreatePost(context,
                    title: "For automakers, Detroit's Dream Cruise should be prime turf to recruit engineers, designers.",
                    body: @"Earlier this year, Automotive News launched a new publication, Fixed Ops Journal, which
                            covers the issues facing managers of the parts, body shop and service departments at new-car dealerships.
                            One central theme that appears over and over again in the magazine, as well as in Automotive News’
                            reporting on the auto industry, is that from the new-car dealer to the manufacturer -- and suppliers,
                            too -- everyone needs more help. Few companies, it seems, can find enough new employees to design, develop
                            and engineer tomorrow’s vehicles, advanced powertrains and components. New-car dealers have been in constant
                            need of technicians for 20 years. Suppliers need every discipline from battery experts to chemists to code
                            writers.",
                    date: new DateTime(2016, 02, 18, 22, 14, 38),
                    authorUsername: "pesho@gmail.com"
                );

                CreatePost(context,
                    title: "Nissan to dangle 5-year, 100,000-mile warranty on 2017 Titan lineup",
                    body: @"Nissan will offer a five-year/100,000-mile, bumper-to-bumper warranty on the 2017 Titan
                            as it prepares to launch two new, volume variants of the large pickup. With the expanded warranty,
                            Nissan hopes the Titan, still unfamiliar to many pickup buyers, will garner more consideration from
                            truck shoppers.",
                    date: new DateTime(2016, 04, 11, 19, 02, 05),
                    authorUsername: "geshu@gmail.com"
                );

                CreatePost(context,
                    title: "The McLaren 570GT MSO comes with added gold",
                    body: @"Ladies and gents, meet the first McLaren 570GT to get the MSO treatment.
                            That stands for McLaren Special Operations, if you need a reminder. 
                            So what you’re seeing here is a 570 that’s just a little bit more, well, special than the rest.
                            It may have ‘GT’ in its name, but the MSO team have decided it definitely needs more noise.
                            So there’s a new titanium exhaust system, which is not only 30 per cent lighter than the stainless steel 
                            item it replaces, but the provider of an “improved aural experience”, too. Good. Not content with titillating
                            our ears, MSO is going for our eyes too. The new exhaust gets a set of new heat shields. That’s a more
                            exciting addition than it sounds, for they are finished in a golden titanium nitride tint. It’s a superb 
                            nod to a similar treatment in the old McLaren F1. And more superb yet given the shields change through blue
                            and purple as they heat up and cool down.",
                    date: new DateTime(2016, 06, 30, 17, 36, 52),
                    authorUsername: "merry@gmail.com"
                );
                CreatePost(context,
                   title: "Americans, this is your new Honda Civic",
                   body: @"And it's being built in Britain. Don't say we never did anything for you. Welcome, Americans, to your brand-new Honda Civic hatchback. Built (probably very well) by the fine men, women and machines of Swindon, no less, it’ll arrive in dealers this ‘fall’. Whenever that is. Developed by Honda’s R&D teams in Europe and Japan, the new Civic promises much. The look is bold (identical to the show car we saw at this year’s Geneva Motor Show), and the handling is touted as ‘world-class’. In the US it’s available with just the one engine – a direct-injection 1.5-litre turbocharged four with up to 180bhp and 162lb ft – across five trim levels. When the new Civic eventually reaches Europe sometime next year, expect diesels and a little 1.0-litre triple. A new Type-R, this time also available in the US, will follow. Good. 
",
                   date: new DateTime(2016, 06, 30, 17, 36, 52),
                   authorUsername: "merry@gmail.com"
               );
                CreatePost(context,
                   title: "The best images from this month's Top Gear magazine",
                   body: @"Road trips special: DB11 across Europe, GT-R in Iceland and Disco Volante Spyder in Italy.
                        In the September issue of Top Gear magazine, we hit the road for our annual summer road trip adventures.
                        After a, erm, ‘slightly strained’ few months with Europe, we turn cultural attaches, cross over the channel
                        and take the new 600bhp Aston Martin DB11 for a 2,500-mile trip across the continent. As a perfect example
                        of what the UK stands for in terms of design, creativity, engineering and technology, we find out if the
                        new DB11 can smooth things over with our European neighbours.",
                   date: new DateTime(2016, 06, 30, 17, 36, 52),
                   authorUsername: "merry@gmail.com"
               );

                CreateGalleryCar(context,
                    title: "Mercedes AMG",
                    url: @" http://media.snimka.bg/s1/5543/037330567.jpg",
                    description: "<b>Year:</b> 2014;</br><b>Engine:</b> 6.2 Liters, 571Hp;</br><b>Acceleration 0-100km/h:</b> 3.7sec;</br><b>Top speed:</b> 320 km/h;");
                
                CreateGalleryCar(context,
                    title: "Chevrolet Camaro",
                    url: @" http://media.snimka.bg/s1/5543/037330568.jpg",
                    description: "<b>Year:</b> 2013;</br><b>Engine:</b> 6.2 Liters, 432Hp;</br><b>Acceleration 0-100km/h:</b> 5.2sec;</br><b>Top speed:</b> 250 km/h;");

                CreateGalleryCar(context,
                    title: "Alfa Romeo 4C Coupe",
                    url: @" http://media.snimka.bg/s1/5543/037330569.jpg",
                    description: "<b>Year:</b> 2015;</br><b>Engine:</b> 1.7 Liters, 240Hp;</br><b>Acceleration 0-100km/h:</b> 4.5sec;</br><b>Top speed:</b> 257 km/h;");

                CreateGalleryCar(context,
                    title: "Lexus LFA",
                    url: @" http://media.snimka.bg/s1/5543/037330570.jpg",
                    description: "<b>Year:</b> 2010;</br><b>Engine:</b> 4.8 Liters, 560Hp;</br><b>Acceleration 0-100km/h:</b> 3.7sec;</br><b>Top speed:</b> 326 km/h;");

                CreateGalleryCar(context,
                    title: "Cadillac CTS 2017",
                    url: @" http://media.snimka.bg/s1/5543/037330571.jpg",
                    description: "<b>Year:</b> 2017;</br><b>Engine:</b> 2.0 Liters, 272Hp;</br><b>Acceleration 0-100km/h:</b> 5.8sec;</br><b>Top speed:</b> Still no information available!!!");
                
                CreateGalleryCar(context,
                   title: "Maserati Quattroporte",
                   url: @" http://media.snimka.bg/s1/5543/037330660.jpg",
                   description: "<b>Year:</b> 2017;</br><b>Engine:</b> 3.8 Liters, 350Hp;</br><b>Acceleration 0-100km/h:</b> 4.7sec;</br><b>Top speed:</b> 307 km/h;");

                CreateGalleryCar(context,
                    title: "Alfa Romeo Giulia",
                    url: @" http://media.snimka.bg/s1/5551/037345848.jpg",
                    description: "<b>Year:</b> 2016;</br><b>Engine:</b> 2.2 Liters, 180Hp;</br><b>Acceleration 0-100km/h:</b> 7.2sec;</br><b>Top speed:</b> 230 km/h;");

                CreateGalleryCar(context,
                    title: "BMW 3er",
                    url: @" http://media.snimka.bg/s1/5551/037345853.jpg",
                    description: "<b>Year:</b> 2015;</br><b>Engine:</b> 2.0 Liters, 184Hp;</br><b>Acceleration 0-100km/h:</b> 7.2sec;</br><b>Top speed:</b> 235 km/h;");

                CreateGalleryCar(context,
                    title: "Mercedes C-class",
                    url: @" http://media.snimka.bg/s1/5551/037345854.jpg",
                    description: "<b>Year:</b> 2014;</br><b>Engine:</b> 2.0 Liters, 184Hp;</br><b>Acceleration 0-100km/h:</b> 7.3sec;</br><b>Top speed:</b> 235 km/h;");

                CreateGalleryCar(context,
                    title: "Lexus IS",
                    url: @" http://media.snimka.bg/s1/5551/037345855.jpg",
                    description: "<b>Year:</b> 2013;</br><b>Engine:</b> 2.5 Liters, 208Hp;</br><b>Acceleration 0-100km/h:</b> 8.1sec;</br><b>Top speed:</b> 225 km/h;");

                CreateGalleryCar(context,
                    title: "Jaguar XE",
                    url: @" http://media.snimka.bg/s1/5551/037345856.jpg",
                    description: "<b>Year:</b> 2015;</br><b>Engine:</b> 2.0 Liters, 200Hp;</br><b>Acceleration 0-100km/h:</b> 7.7sec;</br><b>Top speed:</b> 237 km/h;");

                CreateGalleryCar(context,
                    title: "Mercedes E350",
                    url: @" http://media.snimka.bg/s1/5543/037330661.jpg",
                    description: "<b>Year:</b> 2013;</br><b>Engine:</b> 3.0 Liters, 252Hp;</br><b>Acceleration 0-100km/h:</b> 6.6sec;</br><b>Top speed:</b> 250 km/h;");

                CreateGalleryCar(context,
                    title: "BMW 5-Series LCI",
                    url: @" http://media.snimka.bg/s1/5543/037330663.jpg",
                    description: "<b>Year:</b> 2015;</br><b>Engine:</b> 3.0 Liters, 340Hp;</br><b>Acceleration 0-100km/h:</b> 5.9sec;</br><b>Top speed:</b> 250 km/h;");
               
                /*CreateGalleryCar(context,
                    title: "Volvo S90 Hybrid",
                    url: @" http://media.snimka.bg/s1/5543/037330664.jpg",
                    description: "<b>Year:</b> 2016;</br><b>Engine:</b> 2.0 Liters, 320Hp;</br><b>Acceleration 0-100km/h:</b> 5.8sec;</br><b>Top speed:</b> Still no information available!!!");*/

                /*CreateGalleryCar(context,
                    title: "Jaguar XF",
                    url: @" http://media.snimka.bg/s1/5551/037345852.jpg",
                    description: "<b>Year:</b> 2015;</br><b>Engine:</b> 3.0 Liters, 320Hp;</br><b>Acceleration 0-100km/h:</b> 5.4sec;</br><b>Top speed:</b> 250 km/h;");*/

                /*CreateGalleryCar(context,
                    title: "Lexus GS-350",
                    url: @" http://media.snimka.bg/s1/5543/037330667.jpg",
                    description: "<b>Year:</b> 2012;</br><b>Engine:</b> 3.5 Liters, 317Hp;</br><b>Acceleration 0-100km/h:</b> 6.3sec;</br><b>Top speed:</b> 223 km/h;");

                CreateGalleryCar(context,
                    title: "BMW 6-Series",
                    url: @" http://media.snimka.bg/s1/5543/037330665.jpg",
                    description: "<b>Year:</b> 2015;</br><b>Engine:</b> 3.0 Liters, 320Hp;</br><b>Acceleration 0-100km/h:</b> 5.3sec;</br><b>Top speed:</b> 250 km/h;");

                CreateGalleryCar(context,
                    title: "Mazda 6",
                    url: @" http://media.snimka.bg/s1/5543/037330666.jpg",
                    description: "<b>Year:</b> 2015;</br><b>Engine:</b> 2.5 Liters, 192Hp;</br><b>Acceleration 0-100km/h:</b> 7.8sec;</br><b>Top speed:</b> 223 km/h;");*/


                CreateVideo(context,
                    videoTitle: "Chevrolet Camaro",
                    videoUrl: @" https://www.youtube.com/embed/z9Lvtv0MP_4",
                    videoDescription: null);

                CreateVideo(context,
                    videoTitle: "Mercedes E-class",
                    videoUrl: @" https://www.youtube.com/embed/wO7ljRl6-WI",
                    videoDescription: null);

                CreateVideo(context,
                    videoTitle: "Mercedes SLS AMG",
                    videoUrl: @" https://www.youtube.com/embed/7fWUiW7ALAM",
                    videoDescription: null);

                
                context.SaveChanges();

                CreateComment(context,
                    text: "This sucks",
                    date: new DateTime(2016, 08, 01, 17, 36, 52),
                    authorUserName: "merry@gmail.com",
                    postId: 2
                    );
                context.SaveChanges();
            }
        }

        private void CreateUser(ApplicationDbContext context,
            string email, string password, string fullName)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FullName = fullName
            };

            var userCreateResult = userManager.Create(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }
        }

        private void CreateRole(ApplicationDbContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(roleName));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }
        }

        private void AddUserToRole(ApplicationDbContext context, string userName, string roleName)
        {
            var user = context.Users.First(u => u.UserName == userName);
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var addAdminRoleResult = userManager.AddToRole(user.Id, roleName);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }

        private void CreatePost(ApplicationDbContext context,
            string title, string body, DateTime date, string authorUsername)
        {
            var post = new Post();
            post.Title = title;
            post.Body = body;
            post.Date = date;
            post.Author = context.Users.Where(u => u.UserName == authorUsername).FirstOrDefault();
            context.Posts.Add(post);
        }

        private void CreateVideo(ApplicationDbContext context, string videoTitle, string videoUrl, string videoDescription)
        {
            var carVideo = new Video();
            carVideo.Title = videoTitle;
            carVideo.Url = videoUrl;
            carVideo.Description = videoDescription;
            context.Videos.Add(carVideo);
        }

        private void CreateGalleryCar(ApplicationDbContext context,
            string title, string url, string description)
        {
            var car = new GalleryCar();
            car.Title = title;
            car.URL = url;
            car.Description = description;
            context.GalleryCars.Add(car);
        }
        
        private void CreateComment(ApplicationDbContext context,string text,int postId,string authorUserName,DateTime date)
        {
            var comment = new Comment();
            comment.Text = text;
            comment.Date = date;
            comment.Author = context.Users.Where(u => u.UserName == authorUserName).FirstOrDefault();
            comment.Post = context.GalleryCars.Where(p => p.Id == postId).FirstOrDefault();
            context.Comments.Add(comment);
        }
    }
}