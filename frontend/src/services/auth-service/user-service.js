const authUrl = "https://localhost:7194";

export class UserService {

    async Sign(url, data) {
        const response = await fetch(`${authUrl}${url}`, {
            method: 'POST',
            body: JSON.stringify(data),
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if(!response.ok) {
            throw new Error (response.error);
        }
        const token = await response.text();
        return token.slice(1,-1);
    }

    async SignIn(data) {
        return await this.Sign('/signIn', data);
    }

    async SignUp(data) {
        return await this.Sign('/signUp', data);
    }
}