import { create } from 'zustand'

export const useProfile = create((set) => ({
    avatarImagePath: "",
    setAvatarImagePath: (avatarPath) => set((state) => ({
        ...state.avatarImagePath,
        avatarImagePath: avatarPath
    }))
}))