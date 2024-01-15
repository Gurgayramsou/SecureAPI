fetch("https://localhost:44332/api/TokenIssuer")
  .then((res) => {
    res
      .json()
      .then((token) => {
        // token comes here then call the value API
        const httpHandler = fetch("https://localhost:44332/api/Values", {
          headers: { authorization: `Bearer ${token}` },
        });

        httpHandler
          .then((resp) =>
            resp.json().then((res) =>
              JSON.parse(res).forEach((stud) => {
                console.log(`Hi ${stud.name}, You are ${stud.age}`);
              })
            )
          )
          .catch((err) => console.error(err));
      })
      .catch((err) => {});
  })
  .catch((err) => console.error(err));
