db.createUser(
    {
        user: process.env.MONGO_INITDB_ROOT_USERNAME,
        pwd: process.env.MONGO_INITDB_ROOT_PASSWORD,
        roles:[
            {
                role: "userAdminAnyDatabase",
                db: process.env.MONGO_INITDB_DATABASE
            }
        ]
    }
);
