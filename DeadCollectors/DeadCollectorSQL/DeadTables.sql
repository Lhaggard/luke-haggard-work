USE DeadCollector
IF EXISTS (SELECT * FROM sys.tables WHERE NAME='AboutUs')
	DROP TABLE AboutUs
	GO

IF EXISTS (SELECT * FROM sys.tables WHERE NAME='Posts')
	DROP TABLE Posts
	GO

IF EXISTS (SELECT * FROM sys.tables WHERE NAME='Categories')
	DROP TABLE Categories
	GO
		CREATE TABLE Categories
		(
		CategoryId int PRIMARY KEY IDENTITY,
		Category varchar(64)
		)
		GO
				CREATE TABLE Posts
(
PostId int PRIMARY KEY IDENTITY,
DatePosted date,
Post nvarchar(max),
IsApproved bit,
Rejected bit,
CategoryId int FOREIGN KEY REFERENCES Categories(CategoryId),
PicturePath nvarchar(256),
UserEmail nvarchar(128) 
)
GO

		CREATE TABLE AboutUs
(
About nvarchar(max)
)
GO


INSERT INTO Categories(Category) VALUES
('Obituaries'),
('Meat Delivery Shedule'), 
('Recent PickUps')
GO

INSERT INTO Posts (Post, IsApproved, CategoryId, PicturePath, UserEmail, DatePosted) VALUES
('<h1 class="entry-title" style="text-align: center;">On St Nicholas</h1>
<p>"Today is St Nicholas Day! Hooray! As a person of the Czech persuasion, St Nicholas day (or <a href="http://www.stnicholascenter.org/pages/czech-republic/">Mikul&aacute;&scaron;</a>) has long been a thing for me, celebrated in the family with stockings full of sugar and oranges, and if you&rsquo;re lucky enough to be in CZ with a huge-ass street party where everyone is dressed up like St Nicholas, angels, and demons, and enjoys freaking kids out.</p>
<p>Now St Nicholas day itself may not be all that important to most of us who were not blessed enough to be Czech or related to Czechs, but we are generally aware of him because it&rsquo;s the St Nicholas legend that gave birth to Santa. We often use Santa and St Nicholas as interchangeable, after all, &lsquo;tis the season and all that.</p>
<p>I thought that on his feast day we might have a quick little chat about the life of St Nicholas so you can understand how none of this street party stuff really relates AT ALL, but why none of that matters.</p>
<p>&nbsp;</p>
<p>SO! We talked <a href="https://twitter.com/GoingMedieval/status/1054430966536650752">a little on twitter</a> about this back in October, but in Edinburgh at the National Portrait Gallery there hangs this absolutely gorgeous triptych of the life of St Nicholas by Gerard David." - https://goingmedievalblog.wordpress.com/2018/12/06/on-st-nicholas/</p>', 1, 1, 'post-image-id-1.jpg', '59473bd8-d836-412f-8979-4d7d1482aa95', '2019-03-31'),
('<h1 class="entry-title" style="text-align: center;">Announcement Time!</h1>
<p>"I am excited to announce that I will be writing &ldquo;The Middle Ages: A Graphic Guide&rdquo;, to be published by Icon in late 2019. You can expect a general guide to the medieval period, with the same level of snark you are used to here, but ALSO pictures.</p>
<p>&nbsp;</p>
<p>Please to buy this, as I need beer, and my cat wants treats. Thanks." - https://goingmedievalblog.wordpress.com/2018/04/04/announcement-time/</p>', 1, 2, 'post-image-id-2.jpg', '59473bd8-d836-412f-8979-4d7d1482aa95', '2019-04-01'),
('<h1 class="entry-title" style="text-align: center;">On the Medieval secret to a balling Christmas, for once.</h1>
<p>"Christmas, amiright? It is A Thing.&nbsp; And every year it seems to creep a bit further into autumn as capitalism demands larger and larger blood sacrifices in order to slake its consumerist thirst. Tra la la.</p>
<p>Now, some people really really dig Christmas, some not so much, and some are just deeply ambivalent and stoked to get some time off. All of this is good and fine and you should be able to do you.</p>
<p>I have found through extensive research (i.e. living) that a lot of people sort of struggle with the Christmas thing because you have said <strong>GIANT BUILD UP</strong>, where everyone you know insists that you &lsquo;get together before Christmas!&rsquo; Also, you need to buy a Christmas jumper to wear to the office do! Also, have you sent out Christmas cards? Also, Christmas is the most meaningful day of the year and you should be spending it with your family and if it isn&rsquo;t magical, then maybe you don&rsquo;t actually love them?" - https://goingmedievalblog.wordpress.com/2017/12/20/on-the-medieval-secret-to-a-balling-christmas-for-once/</p>', 1, 3, 'post-image-id-3.jpg', '59473bd8-d836-412f-8979-4d7d1482aa95', '2019-04-02')
GO