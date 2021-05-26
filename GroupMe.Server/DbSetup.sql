CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS groups(
  id INT AUTO_INCREMENT NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) NOT NULL COMMENT 'Group Name',
  creatorId VARCHAR(255) NOT NULL COMMENT 'FK: User Account',
  img varchar(255) COMMENT 'Group Primary Image Url',
  description VARCHAR(255) COMMENT 'Group Description',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS group_members(
  id INT AUTO_INCREMENT NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  accountId varchar(255) NOT NULL COMMENT 'FK: User Account',
  groupId int NOT NULL COMMENT 'FK: Group',
  role varchar(255) DEFAULT "member" COMMENT 'User role in group',
  FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (groupId) REFERENCES groups(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS comments(
  id INT AUTO_INCREMENT NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId varchar(255) NOT NULL COMMENT 'FK: User Account',
  body varchar(255) DEFAULT "empty comment" COMMENT 'Comment Body',
  groupId int NOT NULL COMMENT 'FK: Group',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (groupId) REFERENCES groups(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
INSERT INTO
  comments(body, groupId, creatorId)
VALUES
  (
    "This is the groups first comment!",
    3,
    "cd5f28ba-d192-4c30-9434-b39c95fdfdfa"
  );
INSERT INTO
  groups(name, description, img, creatorId)
VALUES
  (
    "CodeWorks Alumni",
    "Let's talk code!!!",
    "//placehold.it/500x500",
    "cd5f28ba-d192-4c30-9434-b39c95fdfdfa"
  );
SELECT
  g.*,
  g.id AS groupId,
  a.name as creatorName,
  a.picture as creatorPic
FROM
  groups g
  JOIN accounts a ON a.id = g.creatorId
WHERE
  g.id = 3;
SELECT
  c.*,
  g.*,
  a.name,
  a.picture
FROM
  comments c
  JOIN accounts a ON c.creatorId = a.id;
  JOIN groups g ON c.groupId = g.id;
WHERE
  groupId = 3;