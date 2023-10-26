export class Profile {
  constructor(data) {
    this.id = data.id;
    this.name = data.name;
    this.picture = data.picture;
    this.coverImg = data.coverImg || 'https://cdn1.jigidi.com/thumbs/3SESVH0N/l';
  }
}

export class Account extends Profile {
  constructor(data) {
    super(data); // calling the constructor of the parent class
    this.email = data.email;
  }
}


// 'https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/7d97b4b8-dd3f-44bf-afc8-33025e350228/dfkgj3y-c30b4e68-c49c-4329-b173-47df585a61db.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzdkOTdiNGI4LWRkM2YtNDRiZi1hZmM4LTMzMDI1ZTM1MDIyOFwvZGZrZ2ozeS1jMzBiNGU2OC1jNDljLTQzMjktYjE3My00N2RmNTg1YTYxZGIucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.rHDKAGhDEfh0aJ1pG09ME09XAxAU_nHUwWjhJ1HkpQw'