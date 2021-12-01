CREATE DATABASE Publication;
USE Publication;

CREATE TABLE AUTHOR( 			
	author_ID BIGINT ,
	author_email varchar(255), 
	a_address varchar(255) NOT NULL, 
	dept varchar(255) NOT NULL, 
	job varchar(255) NOT NULL,
    UNIQUE(author_ID, author_email),
    PRIMARY KEY(author_ID)
); 
CREATE TABLE ARTICLE( 			
	article_ID BIGINT, 
	summary TEXT NOT NULL, 
	file_bb varchar(255) NOT NULL, 
	p_status varchar(255) NOT NULL, 
	title varchar(255) NOT NULL, 
	keyword char(10) NOT NULL,
    send_date date NOT NULL,
    cAuthor_ID BIGINT NOT NULL,
    review_ID BIGINT,
    UNIQUE(file_bb, article_ID, cAuthor_ID,review_ID),
    PRIMARY KEY(article_ID),
    FOREIGN KEY(cAuthor_ID) 
		REFERENCES AUTHOR(author_ID)
); 


CREATE TABLE REVIEWER( 			
	reviewer_ID BIGINT,
	phone_number NUMERIC, 
	p_level varchar(255) NOT NULL, 
	r_address varchar(255) NOT NULL,
	p_email varchar(255) NOT NULL, 
	d_email varchar(255) NOT NULL, 
	expertise varchar(255) NOT NULL, 
	fname varchar(255) NOT NULL, 
	job varchar(255) NOT NULL, 
	dept varchar(255) NOT NULL, 
	coop_date date NOT NULL,
    UNIQUE(reviewer_ID, p_email, d_email), 
    PRIMARY KEY(reviewer_ID)
); 

CREATE TABLE NGUOI_PHAN_BIEN(
author_ID BIGINT,
reviewer_ID BIGINT,
UNIQUE(author_ID, reviewer_ID),
FOREIGN KEY(author_ID)
	REFERENCES AUTHOR(author_ID),
FOREIGN KEY(reviewer_ID)
	REFERENCES REVIEWER(reviewer_ID)
);

CREATE TABLE REVIEW( 			
	review_ID BIGINT, 
    article_ID BIGINT NOT NULL,
    UNIQUE(article_ID),
    PRIMARY KEY(review_ID),
    FOREIGN KEY(article_ID) 
		REFERENCES ARTICLE(article_ID)
);
ALTER TABLE ARTICLE 
ADD FOREIGN KEY(review_ID) 
		REFERENCES REVIEW(review_ID);

CREATE TABLE REVIEW_CRITERIA (		
	score int,
	r_description text NOT NULL,
	details text NOT NULL,
    PRIMARY KEY(score)
) ;


CREATE TABLE BAN_BIEN_TAP (
	ban_bien_tap_ID BIGINT,
	ban_bien_tap_email varchar(255) NOT NULL,
    reviewer_ID BIGINT,
    UNIQUE(ban_bien_tap_ID, ban_bien_tap_email,reviewer_ID),
    PRIMARY KEY(ban_bien_tap_ID),
    FOREIGN KEY(reviewer_ID)
		REFERENCES REVIEWER(reviewer_ID)
);


CREATE TABLE UPDATE_STATUS (		
	result varchar(20) NOT NULL CHECK( result IN('posted','published','reviewing','review feedback','review completed')),
	ban_bien_tap_ID BIGINT NOT NULL,
	article_ID BIGINT NOT NULL,
    UNIQUE(article_ID),
	FOREIGN KEY (ban_bien_tap_ID) 
		REFERENCES BAN_BIEN_TAP (ban_bien_tap_ID)
        ON DELETE NO ACTION
        ON UPDATE CASCADE,
	FOREIGN KEY (article_ID) 
		REFERENCES ARTICLE (article_ID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
) ;

CREATE TABLE WRITING (				
	author_ID BIGINT NOT NULL,
	article_ID BIGINT NOT NULL,
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
	P_length int NOT NULL CHECK (P_length >= 10 AND P_length<=20),
	article_ID BIGINT NOT NULL,
    UNIQUE(article_ID),
	FOREIGN KEY (article_ID) 
		REFERENCES ARTICLE (article_ID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);


CREATE TABLE OVERVIEW (			
	P_length int NOT NULL CHECK (P_length >= 10 AND P_length<=20),
	article_ID BIGINT NOT NULL,
    UNIQUE(article_ID),
	FOREIGN KEY (article_ID) 
		REFERENCES ARTICLE (article_ID)
		ON DELETE CASCADE
        ON UPDATE CASCADE
);


CREATE TABLE BOOK_REVIEW (			
	ISBN BIGINT,
	authors varchar(255) NOT NULL,
	book_name varchar(255) NOT NULL,
	publisher varchar(255) NOT NULL,
	publish_year date NOT NULL,
	P_length int NOT NULL CHECK (P_length >= 10 AND P_length<=20),
	total_page int NOT NULL,
	article_ID BIGINT NOT NULL,
    UNIQUE(article_ID, ISBN),
    PRIMARY KEY (ISBN),
	FOREIGN KEY (article_ID) 
		REFERENCES ARTICLE (article_ID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);


CREATE TABLE UPDATE_RESULT (	
	result VARCHAR(20) NOT NULL CHECK (result IN('minor revision', 'major revision', 'acceptance','rejection')),
	noti_date date NOT NULL, 
	other_detail text , 
	ban_bien_tap_ID BIGINT NOT NULL,
	review_ID BIGINT NOT NULL,
	UNIQUE(review_ID),
	FOREIGN KEY (ban_bien_tap_ID) 
		REFERENCES BAN_BIEN_TAP (ban_bien_tap_ID)
        ON DELETE NO ACTION
        ON UPDATE CASCADE,
	FOREIGN KEY (review_ID) 
		REFERENCES REVIEW (review_ID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);


CREATE TABLE REVIEW_DIRECTING (		
	ban_bien_tap_ID BIGINT NOT NULL,
	reviewer_ID BIGINT NOT NULL,
	FOREIGN KEY (ban_bien_tap_ID) 
		REFERENCES BAN_BIEN_TAP (ban_bien_tap_ID)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	FOREIGN KEY (reviewer_ID) 
		REFERENCES REVIEWER (reviewer_ID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);


CREATE TABLE REVIEWING (			
	reviewer_ID BIGINT NOT NULL,
	score int NOT NULL,
	e_note text, a_note text,
	review_ID BIGINT NOT NULL,
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