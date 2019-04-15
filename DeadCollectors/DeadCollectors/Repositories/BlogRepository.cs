
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadCollectors.Models {
    public class BlogRepository
    {

        private static ApplicationDbContext context = new ApplicationDbContext();

        private UserManager<ApplicationUser> _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

        private RoleManager<IdentityRole> _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

        public List<Post> SearchPosts(string category, string term)
        {
            List<Post> posts = new List<Post>();

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString =
                    ConfigurationManager.ConnectionStrings["DeadCollector"].ConnectionString;

                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SearchByCategory"
                };
                sqlCommand.Parameters.AddWithValue("@Category", category);
                sqlCommand.Parameters.AddWithValue("@Tag", term);

                sqlConnection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Post post = new Post
                        {
                            PostID = (int) dataReader["PostId"],
                            Body = dataReader["Post"].ToString(),
                            Creation = (DateTime) dataReader["DatePosted"],
                            IsApproved = (bool) dataReader["IsApproved"],
                            Photo = dataReader["PicturePath"].ToString()
                        };

                        post.Category = new Category
                        {
                            Name = dataReader["Category"].ToString()
                        };

                        post.User = new ApplicationUser
                        {
                            Email = dataReader["UserEmail"].ToString()
                        };

                        posts.Add(post);
                    }
                }
            }

            return posts;
        }

        public void AddPost(Post post)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString =
                    ConfigurationManager.ConnectionStrings["DeadCollector"].ConnectionString;

                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "AddPost"
                };
                sqlCommand.Parameters.AddWithValue("@Post", post.Body);
                sqlCommand.Parameters.AddWithValue("@PostedBy", post.User.Email);
                sqlCommand.Parameters.AddWithValue("@IsApproved", post.IsApproved);
                sqlCommand.Parameters.AddWithValue("@CategoryId", post.Category.ID);
                sqlCommand.Parameters.AddWithValue("@PicturePath", post.Photo);

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
        }

        public List<Post> GetThreeMostRecentPosts()
        {
            List<Post> posts = new List<Post>();

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString =
                    ConfigurationManager.ConnectionStrings["DeadCollector"].ConnectionString;

                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetThreeMostRecentPosts"
                };

                sqlConnection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Post post = new Post
                        {
                            PostID = (int) dataReader["PostID"],
                            Body = dataReader["Post"].ToString(),
                            Creation = (DateTime) dataReader["DatePosted"],
                            IsApproved = (bool) dataReader["IsApproved"]
                        };

                        post.Category = new Category
                        {
                            Name = dataReader["Category"].ToString()
                        };

                        post.User = new ApplicationUser
                        {
                            Email = dataReader["UserEmail"].ToString()
                        };

                        posts.Add(post);
                    }
                }
            }

            return posts;
        }

        public Post GetPost(int id)
        {
            Post post = new Post
            {
                Category = new Category(),
                User = new ApplicationUser()
            };
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString =
                    ConfigurationManager.ConnectionStrings["DeadCollector"].ConnectionString;

                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetPost"
                };

                sqlCommand.Parameters.AddWithValue("@PostId", id);

                sqlConnection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        post.PostID = (int) dataReader["PostID"];
                        post.User.Email = dataReader["UserEmail"].ToString();
                        post.Body = dataReader["Post"].ToString();
                        post.Creation = (DateTime) dataReader["DatePosted"];
                        post.IsApproved = (bool) dataReader["IsApproved"];
                        post.Category.Name = dataReader["Category"].ToString();
                        post.Photo = dataReader["PicturePath"].ToString();
                    }
                }
            }

            return post;
        }

        public void EditPost(Post post)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString =
                    ConfigurationManager.ConnectionStrings["DeadCollector"].ConnectionString;

                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "UpdatePost"
                };

                sqlCommand.Parameters.AddWithValue("@PostId", post.PostID);
                sqlCommand.Parameters.AddWithValue("@Post", post.Body);
                sqlCommand.Parameters.AddWithValue("@IsApproved", post.IsApproved);
                sqlCommand.Parameters.AddWithValue("@Category", post.Category.Name);
                sqlCommand.Parameters.AddWithValue("@UserEmail", post.User.Email);
                sqlCommand.Parameters.AddWithValue("@PicturePath", post.Photo);

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
        }

        public void DeletePost(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString =
                    ConfigurationManager.ConnectionStrings["DeadCollector"].ConnectionString;

                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DeletePost"
                };

                sqlCommand.Parameters.AddWithValue("@PostId", id);

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
        }

        public List<Post> GetPendingPosts()
        {
            List<Post> posts = new List<Post>();

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString =
                    ConfigurationManager.ConnectionStrings["DeadCollector"].ConnectionString;

                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetPendingPosts"
                };

                sqlConnection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Post post = new Post
                        {
                            PostID = (int) dataReader["PostID"],
                            Body = dataReader["Post"].ToString(),
                            Creation = (DateTime) dataReader["DatePosted"],
                            IsApproved = (bool) dataReader["IsApproved"]
                        };

                        post.Category = new Category
                        {
                            Name = dataReader["Category"].ToString()
                        };

                        post.User = new ApplicationUser
                        {
                            Email = dataReader["UserEmail"].ToString()
                        };

                        posts.Add(post);
                    }
                }
            }

            return posts;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString =
                    ConfigurationManager.ConnectionStrings["DeadCollector"].ConnectionString;

                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetCategories"
                };

                sqlConnection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Category category = new Category
                        {
                            ID = (int) dataReader["CategoryId"],
                            Name = dataReader["Category"].ToString()
                        };

                        categories.Add(category);
                    }
                }
            }

            return categories;
        }

        public List<IdentityRole> GetRoles()
        {
            return _roleManager.Roles.ToList();
        }

        public List<ApplicationUser> GetUsers()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();

            using (SqlConnection sqlConnection = new SqlConnection()) {
                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["DeadCollector"].ConnectionString;

                SqlCommand sqlCommand = new SqlCommand {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetUsers"
                };

                sqlConnection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader()) {
                    while (dataReader.Read()) {
                        ApplicationUser user = new ApplicationUser {
                            Id = dataReader["Id"].ToString(),
                            Email = dataReader["Email"].ToString()
                        };

                        users.Add(user);
                    }
                }
            }

            return users;
        }

        public void ApprovePost(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString =
                    ConfigurationManager.ConnectionStrings["DeadCollector"].ConnectionString;

                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "ApprovePost"
                };

                sqlCommand.Parameters.AddWithValue("@PostId", id);

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
        }

        public List<Post> GetApprovedPosts()
        {
            List<Post> posts = new List<Post>();

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString =
                    ConfigurationManager.ConnectionStrings["DeadCollector"].ConnectionString;

                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetApprovedPosts"
                };

                sqlConnection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Post post = new Post
                        {
                            PostID = (int) dataReader["PostID"],
                            Body = dataReader["Post"].ToString(),
                            Creation = (DateTime) dataReader["DatePosted"],
                            IsApproved = (bool) dataReader["IsApproved"],
                            Photo = dataReader["PicturePath"].ToString()
                        };

                        post.Category = new Category
                        {
                            Name = dataReader["Category"].ToString()
                        };

                        post.User = new ApplicationUser
                        {
                            Email = dataReader["UserEmail"].ToString()
                        };
                        posts.Add(post);
                    }
                }
            }

            return posts;
        }

        public string GetRoleName(string userId)
        {
            var roles = _userManager.GetRoles(userId).ToList();

            return roles.FirstOrDefault();
        }

        public int GetNextPostID()
        {
            int nextID = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["DeadCollector"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("NextPostId", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nextID = (int) reader["NextPostId"];
                    }
                }
            }

            return nextID;
        }

        public AboutUs GetAboutUs()
        {
            var aboutUs = new AboutUs();

            string connectionString = ConfigurationManager.ConnectionStrings["DeadCollector"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetAboutUs", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        aboutUs.AboutUsHTML = reader["About"].ToString();
                    }
                }
            }

            return aboutUs;
        }

        public void EditAboutUs(AboutUs aboutUs)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DeadCollector"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("EditAboutUs", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@About", aboutUs.AboutUsHTML);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
