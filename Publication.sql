CREATE DATABASE Publication;
USE Publication;

CREATE TABLE AUTHOR( 			
	author_ID BIGINT IDENTITY(1,1) ,
	author_email varchar(255), 
	a_address varchar(255), 
	dept varchar(255), 
	job varchar(255),
	reviewer_ID BIGINT,
    UNIQUE(author_ID, author_email, reviewer_ID),
    PRIMARY KEY(author_ID),
); 
CREATE TABLE ARTICLE( 			
	article_ID BIGINT IDENTITY(1,1), 
	summary TEXT, 
	file_bb varchar(255), 
	p_status varchar(255), 
	title varchar(255), 
	result varchar(20),
	keyword char(10),
    send_date date ,
    cAuthor_ID BIGINT ,
    review_ID BIGINT ,
    UNIQUE(file_bb, article_ID,review_ID),
    PRIMARY KEY(article_ID),
    FOREIGN KEY(cAuthor_ID) 
		REFERENCES AUTHOR(author_ID)
); 


CREATE TABLE REVIEWER( 			
	reviewer_ID BIGINT IDENTITY(1,1),
	phone_number NUMERIC, 
	p_level varchar(255) , 
	r_address varchar(255) ,
	p_email varchar(255) , 
	d_email varchar(255) , 
	expertise varchar(255) , 
	fname varchar(255) , 
	job varchar(255) , 
	dept varchar(255) , 
	coop_date date ,
    UNIQUE(reviewer_ID, p_email, d_email), 
    PRIMARY KEY(reviewer_ID)
); 

CREATE TABLE REVIEW( 			
	review_ID BIGINT IDENTITY(1,1), 
	result VARCHAR(20),
	noti_date date , 
	other_detail text , 
    article_ID BIGINT ,
	reviewer_ID BIGINT,
    UNIQUE(article_ID),
    PRIMARY KEY(review_ID),
    FOREIGN KEY(article_ID) 
		REFERENCES ARTICLE(article_ID),
	FOREIGN KEY(reviewer_ID)
		REFERENCES REVIEWER(reviewer_ID)
);
ALTER TABLE ARTICLE 
ADD FOREIGN KEY(review_ID) 
		REFERENCES REVIEW(review_ID);

ALTER TABLE AUTHOR 
ADD FOREIGN KEY(reviewer_ID)
		REFERENCES REVIEWER(reviewer_ID);

CREATE TABLE REVIEW_CRITERIA (		
	score int,
	r_description text ,
	details text ,
    PRIMARY KEY(score)
) ;


CREATE TABLE BAN_BIEN_TAP (
	ban_bien_tap_ID BIGINT IDENTITY(1,1),
	ban_bien_tap_email varchar(255) ,
	reviewer_ID BIGINT,
    UNIQUE(ban_bien_tap_ID, ban_bien_tap_email,reviewer_ID),
    PRIMARY KEY(ban_bien_tap_ID),
    FOREIGN KEY(reviewer_ID)
		REFERENCES REVIEWER(reviewer_ID)
);

CREATE TABLE WRITING (				
	author_ID BIGINT ,
	article_ID BIGINT ,
	FOREIGN KEY (author_ID) 
		REFERENCES AUTHOR (author_ID)
        ON DELETE NO ACTION
        ON UPDATE CASCADE,
	FOREIGN KEY (article_ID) 
		REFERENCES ARTICLE (article_ID)
        ON DELETE NO ACTION
        ON UPDATE CASCADE
);


CREATE TABLE RESEARCH (			
	P_length int  CHECK (P_length >= 10 AND P_length<=20),
	article_ID BIGINT ,
    UNIQUE(article_ID),
	FOREIGN KEY (article_ID) 
		REFERENCES ARTICLE (article_ID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);


CREATE TABLE OVERVIEW (			
	P_length int  CHECK (P_length >= 3 AND P_length<=20),
	article_ID BIGINT ,
    UNIQUE(article_ID),
	FOREIGN KEY (article_ID) 
		REFERENCES ARTICLE (article_ID)
		ON DELETE CASCADE
        ON UPDATE CASCADE
);


CREATE TABLE BOOK_REVIEW (			
	ISBN BIGINT,
	authors varchar(255) ,
	book_name varchar(255) ,
	publisher varchar(255) ,
	publish_year date ,
	P_length int  CHECK (P_length >= 10 AND P_length<=20),
	total_page int ,
	article_ID BIGINT ,
    UNIQUE(article_ID, ISBN),
    PRIMARY KEY (ISBN),
	FOREIGN KEY (article_ID) 
		REFERENCES ARTICLE (article_ID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);


CREATE TABLE REVIEWING (			
	reviewer_ID BIGINT ,
	score int ,
	e_note text, a_note text,
	review_ID BIGINT ,
    UNIQUE(review_ID),
	FOREIGN KEY (reviewer_ID) 
		REFERENCES REVIEWER (reviewer_ID)
        ON DELETE NO ACTION
        ON UPDATE CASCADE,
	FOREIGN KEY (review_ID) 
		REFERENCES REVIEW (review_ID)
		ON DELETE NO ACTION
        ON UPDATE CASCADE,
	FOREIGN KEY (score) 
		REFERENCES REVIEW_CRITERIA (score)
        ON DELETE NO ACTION
        ON UPDATE CASCADE
);

CREATE TABLE USERINFO (
	username varchar(50) ,
	u_password varchar(50) ,
	usertype varchar(50) ,
);

DROP TABLE REVIEW;
