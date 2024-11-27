import { create } from 'zustand'

export const useAuth = create((set) => ({
    auth: {
        id : "",
        email: "",
        username: "",
        roles: [],
        accessToken: "",
        avatarPath: ""
    },
    setAuth: (authInfo) => set((state) => ({
        auth: {
            id: authInfo.id,
            email: authInfo.email,
            username: authInfo.username,
            roles: authInfo.roles,
            accessToken: authInfo.accessToken,
            avatarPath: authInfo.avatarPath
        }
    })),
    setAvatarImage: (avatarImagePath) => set((state) => ({
        auth: {
            ...state.auth,
            avatarPath: avatarImagePath
        }
    }))
}))