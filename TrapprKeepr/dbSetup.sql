CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(1000) COMMENT 'User Picture',
        coverImg varchar(1000) COMMENT 'Cover Image'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS vaults(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        name VARCHAR(255) NOT NULL,
        description VARCHAR(255) NOT NULL,
        category ENUM(
            'misc',
            'unicorns',
            'dragons',
            'gryphons',
            'mermaids',
            'faeries',
            'fluffies'
        ) DEFAULT 'misc',
        img VARCHAR(1000) NOT NULL,
        isPrivate BOOLEAN DEFAULT FALSE,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS keeps(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        name VARCHAR(500) NOT NULL,
        description VARCHAR(500) NOT NULL,
        img VARCHAR(1000) NOT NULL,
        views INT DEFAULT 0,
        kept INT DEFAULT 0,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS vaultKeeps(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        vaultId INT NOT NULL,
        keepId INT NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
        FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

INSERT INTO 

vaults ( name, description, 

img, 

creatorId 

) 

VALUES ( 

'TIFFtest', 

'lets see what happens', 

'https://thumbs.dreamstime.com/b/colorful-rainbow-unicorn-horse-ancient-mythical-creature-187650428.jpg',

'6532bb3d577b39d02c12a556' 

) 

SELECT vake.*, vau.*
FROM vaultKeeps vake
    JOIN vaults vau ON vau.id = vake.vaultId
WHERE
    vake.creatorId = @creatorId;

-- INSERT INTO

--     vaultKeeps (vaultId, keepId, creatorId)

-- VALUES (

--         2,

--         2,

--         '653a0296be4201188c706794', (

--             2,

--             3,

--             '653a0296be4201188c706794', (

--                 3,

--                 4,

--                 '653a0296be4201188c706794', (

--                     3,

--                     5,

--                     '653a0296be4201188c706794', (

--                         4,

--                         6,

--                         '653a0296be4201188c706794', (

--                             4,

--                             8,

--                             '653a0296be4201188c706794', (

--                                 5,

--                                 9,

--                                 '653a0296be4201188c706794', (

--                                     5,

--                                     11,

--                                     '653a0296be4201188c706794', (

--                                         7,

--                                         12,

--                                         '653a0296be4201188c706794', (

--                                             8,

--                                             2,

--                                             '653a0296be4201188c706794',

SELECT
    kee.*,
    act.*,
    COUNT(vk.id) AS kept
FROM keeps kee
    JOIN accounts act ON kee.creatorId = act.id
    JOIN `vaultKeeps` vk ON vk.`keepId` = kee.id
WHERE kee.id = 5
GROUP BY (kee.id);

INSERT INTO
    `vaultKeeps` (
        `keepId`,
        `vaultId`,
        `creatorId`
    )
VALUES (
        5,
        2,
        '653a0296be4201188c706794'
    );

SELECT * from `vaultKeeps` WHERE `keepId` = 5;