use TaskManager;

CREATE TABLE Tasks (
	id INT IDENTITY (1,1) PRIMARY KEY,
	title VARCHAR(64) NOT NULL,
	contents VARCHAR(1000) NOT NULL,
	add_date DATETIME NOT NULL,
	end_date DATETIME NOT NULL,
	task_priority INT NOT NULL,
	task_state INT NOT NULL
);

CREATE TABLE Notes (
	id INT IDENTITY (1,1) PRIMARY KEY,
	task_id INT NOT NULL,
	contents VARCHAR(255) NOT NULL,
	added DATETIME NOT NULL,
	FOREIGN KEY (task_id)
		REFERENCES Tasks (id)
		ON DELETE CASCADE ON UPDATE CASCADE
);