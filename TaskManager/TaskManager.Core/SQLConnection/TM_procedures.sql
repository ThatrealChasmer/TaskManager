use TaskManager;
GO

CREATE PROCEDURE GetTasks
AS
	select * from Tasks;
GO

CREATE PROCEDURE AddTask @title varchar(64), @contents varchar(1000), @add_date datetime, @end_date datetime = null, @task_priority tinyint, @task_state tinyint
AS
	INSERT INTO TaskManager.dbo.Tasks(title, contents, add_date, end_date, task_priority, task_state) VALUES (@title, @contents, @add_date, @end_date, @task_priority, @task_state);
GO

CREATE PROCEDURE EditTask @id int, @title varchar(64), @contents varchar(1000), @add_date datetime, @end_date datetime = null, @task_priority tinyint, @task_state tinyint
AS
	UPDATE TaskManager.dbo.Tasks SET title=@title, contents=@contents, add_date=@add_date, end_date=@end_date, task_priority=@task_priority, task_state=@task_state WHERE id=@id;
GO

CREATE PROCEDURE DeleteTask @id int
AS
	DELETE FROM TaskManager.dbo.Tasks WHERE id=@id;
GO

CREATE PROCEDURE MoveTask @id int, @task_state tinyint
AS
	UPDATE TaskManager.dbo.Tasks SET task_state=@task_state WHERE id=@id;
GO

CREATE PROCEDURE GetNotes @t_id int
AS
	select * from Notes where task_id = @t_id;
GO

CREATE PROCEDURE AddNote @task_id int, @added datetime, @contents varchar(255)
AS
	INSERT INTO TaskManager.dbo.Notes(task_id, added, contents) VALUES (@task_id, @added, @contents);
GO

CREATE PROCEDURE DeleteNote @id int
AS
	DELETE FROM TaskManager.dbo.Notes WHERE id=@id
GO